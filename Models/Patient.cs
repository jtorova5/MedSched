using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedSched.Models;

[Table("patients")]
public class Patient
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("name")]
    public string Name { get; set; }

    [Required]
    [Column("birthdate")]
    public DateTime Birthdate { get; set; }

    [Required]
    [MaxLength(15)]
    [Column("contact_number")]
    public string ContactNumber { get; set; }

    // New fields for authentication
    [Required]
    [EmailAddress]
    [MaxLength(255)]
    [Column("email")]
    public string Email { get; set; }

    [Required]
    [MinLength(3)]
    [Column("password")]
    public string Password { get; set; }
    
    public Patient(string name, DateTime birthdate, string contactNumber, string email, string password)
    {
        Name = name.Trim();
        Birthdate = birthdate;
        ContactNumber = contactNumber.Trim();
        Email = email.Trim();
        Password = password.Trim();
    }

    public Patient() { }
}
