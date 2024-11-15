using System.ComponentModel.DataAnnotations;

namespace MedSched.DTOs.Requests;

public class DoctorDTO
{
    [Required(ErrorMessage = "Doctor Name is required")]
    [MaxLength(100, ErrorMessage = "Doctor's name can't be longer than 100 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Specialization is required")]
    [MaxLength(100, ErrorMessage = "Specialization can't be longer than 100 characters")]
    public string Specialization { get; set; }

    [Required(ErrorMessage = "Doctor's availability status is required")]
    public bool Availability { get; set; }
}

