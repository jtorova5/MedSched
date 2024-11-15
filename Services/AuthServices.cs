
using MedSched.Data;
using MedSched.Models;
using MedSched.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MedSched.Services;

// Implementing the IAuthService interface
public class AuthService : IAuthRepository
{
    private readonly AppDbContext _context;
    private readonly string _jwtSecretKey;
    private readonly string _jwtIssuer;
    private readonly string _jwtAudience;

    public AuthService(AppDbContext context)
    {
        _context = context;
        _jwtSecretKey = Environment.GetEnvironmentVariable("JWT_KEY");
        _jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
        _jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
    }

    // Method to authenticate a user (doctor or patient) and generate a JWT token
    public async Task<JwtSecurityToken> LoginAsync(string email, string password)
    {
        // Check if the user is a doctor or a patient by searching by email
        var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Email == email);
        if (doctor != null && doctor.Password == password)
        {
            return GenerateJwtToken(doctor.Id, doctor.Email, "doctor");
        }

        var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Email == email);
        if (patient != null && patient.Password == password)
        {
            return GenerateJwtToken(patient.Id, patient.Email, "patient");
        }

        // If no matching user found, return null
        return null;
    }

    // Generate JWT token for authenticated user
    private JwtSecurityToken GenerateJwtToken(int userId, string email, string role)
    {
        var claims = new[]
        {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Email, email),
                new Claim("role", role)  // Adding role claim (doctor or patient)
            };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtIssuer,
            audience: _jwtAudience,
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
        );

        return token;
    }
}



