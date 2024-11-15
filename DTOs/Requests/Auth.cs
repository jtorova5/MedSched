namespace MedSched.Models;

public class LoginRequest
{
    // Email of the user (doctor or patient)
    public string Email { get; set; }

    // Password of the user (doctor or patient)
    public string Password { get; set; }
}

