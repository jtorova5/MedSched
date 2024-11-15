using System.ComponentModel.DataAnnotations;

namespace MedSched.DTOs.Requests;

public class AppointmentDTO
{
    [Required(ErrorMessage = "Appointment Date is required")]
    public DateTime AppointmentDate { get; set; }

    [Required(ErrorMessage = "Status is required")]
    [MaxLength(20, ErrorMessage = "Status can't be longer than 20 characters")]
    public string Status { get; set; }

    [Required(ErrorMessage = "Patient Id is required")]
    public int PatientId { get; set; }

    [Required(ErrorMessage = "Doctor Id is required")]
    public int DoctorId { get; set; }
}


