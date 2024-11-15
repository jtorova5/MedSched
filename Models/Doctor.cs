using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedSched.Models;

[Table("doctors")]
public class Doctor
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
    [MaxLength(100)]
    [Column("specialization")]
    public string Specialization { get; set; }

    [Required]
    [Column("availability")]
    public bool Availability { get; set; }

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
    
    public Doctor(string name, string specialization, bool availability, string email, string password)
    {
        Name = name.Trim();
        Specialization = specialization.Trim();
        Availability = availability;
        Email = email.Trim();
        Password = password.Trim();
    }

    public Doctor() { }
}
