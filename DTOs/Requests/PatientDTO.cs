using System.ComponentModel.DataAnnotations;

namespace MedSched.DTOs.Requests;

public class PatientDTO
{
    [Required(ErrorMessage = "Patient Name is required")]
    [MaxLength(100, ErrorMessage = "Patient's name can't be longer than 100 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Birthdate is required")]
    public DateTime Birthdate { get; set; }

    [Required(ErrorMessage = "Contact Number is required")]
    [MaxLength(15, ErrorMessage = "Contact number can't be longer than 15 characters")]
    public string ContactNumber { get; set; }
}



