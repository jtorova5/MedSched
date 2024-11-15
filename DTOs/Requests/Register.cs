using System.ComponentModel.DataAnnotations;

public class RegisterRequest
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string Role { get; set; } // e.g., "Doctor" or "Patient"
}
