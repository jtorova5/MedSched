using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using MedSched.Models;
using Microsoft.IdentityModel.Tokens;

namespace MedSched.Config;

public class Utilities
{
    // Method to hash a string using SHA256 algorithm
    public string EncryptSHA256(string input)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(input));
        StringBuilder builder = new();
        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2"));
        }
        return builder.ToString();
    }

    // Method to generate a JWT token for either a Doctor or a Patient
    public string GenerateJwtToken(object user)
    {
        // Check if the user is a Patient or a Doctor
        Claim[] claims;
        if (user is Patient patient)
        {
            claims = new[]
            {
                    new Claim(ClaimTypes.NameIdentifier, patient.Id.ToString()),  // User ID
                    new Claim(ClaimTypes.Email, patient.Email),                    // User Email
                    new Claim(ClaimTypes.Name, patient.Name),                      // User Name
                    new Claim("role", "Patient")                                    // Role claim for Patient
                };
        }
        else if (user is Doctor doctor)
        {
            claims = new[]
            {
                    new Claim(ClaimTypes.NameIdentifier, doctor.Id.ToString()),   // User ID
                    new Claim(ClaimTypes.Email, doctor.Email),                     // User Email
                    new Claim(ClaimTypes.Name, doctor.Name),                       // User Name
                    new Claim("role", "Doctor")                                    // Role claim for Doctor
                };
        }
        else
        {
            throw new ArgumentException("User must be of type Patient or Doctor", nameof(user));
        }

        // Get JWT configuration values from environment variables
        var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");
        var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
        var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
        var jwtExpiresIn = Environment.GetEnvironmentVariable("JWT_EXPIRES_IN");

        // Ensure all JWT configuration values are set
        if (string.IsNullOrEmpty(jwtKey) || string.IsNullOrEmpty(jwtIssuer) || string.IsNullOrEmpty(jwtAudience))
        {
            throw new InvalidOperationException("JWT configuration values are missing.");
        }

        // Create a symmetric key for signing the JWT
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Create the JWT token with claims and expiration time
        var token = new JwtSecurityToken(
            issuer: jwtIssuer,
            audience: jwtAudience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtExpiresIn)), // Token expiration time
            signingCredentials: credentials
        );

        // Return the token as a string
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

