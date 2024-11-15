using MedSched.Services;
using MedSched.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using MedSched.Repositories;

namespace MedSched.Controllers.V1.Auth;

[ApiController]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthRepository _authService;

    // Injecting the IAuthService interface
    public AuthController(IAuthRepository authService)
    {
        _authService = authService;
    }

    // Login endpoint to authenticate both doctors and patients
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        // Call AuthService to get the JWT token based on the provided email and password
        var jwtToken = await _authService.LoginAsync(request.Email, request.Password);

        if (jwtToken == null)
        {
            // Return Unauthorized if no valid JWT token is returned
            return Unauthorized(new { message = "Invalid email or password" });
        }

        // Assuming jwtToken includes a claim for the role (doctor or patient)
        var role = jwtToken.Claims.FirstOrDefault(c => c.Type == "role")?.Value;

        // If no role is found, return Unauthorized
        if (role == null)
        {
            return Unauthorized(new { message = "Invalid user role" });
        }

        // Create a LoginResponse DTO with the JWT and Role
        var loginResponse = new LoginResponse
        {
            Jwt = new JwtSecurityTokenHandler().WriteToken(jwtToken),
            Role = role
        };

        // Return the LoginResponse
        return Ok(loginResponse);
    }
}

