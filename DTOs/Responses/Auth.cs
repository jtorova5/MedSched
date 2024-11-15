namespace MedSched.Models;

public class LoginResponse
{
    // JWT token generated for the user
    public string Jwt { get; set; }

    // Role of the user (either 'doctor' or 'patient')
    public string Role { get; set; }
}

