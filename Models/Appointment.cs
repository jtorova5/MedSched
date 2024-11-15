using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedSched.Models;

[Table("appointments")]
public class Appointment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("appointment_date")]
    public DateTime AppointmentDate { get; set; }

    [Required]
    [Column("status")]
    [MaxLength(20)]
    public string Status { get; set; }

    [Required]
    [Column("patient_id")]
    [ForeignKey("PatientId")]
    public int PatientId { get; set; }

    [Required]
    [Column("doctor_id")]
    [ForeignKey("DoctorId")]
    public int DoctorId { get; set; }

    public Appointment(DateTime appointmentDate, string status, int patientId, int doctorId)
    {
        AppointmentDate = appointmentDate;
        Status = status.Trim();
        PatientId = patientId;
        DoctorId = doctorId;
    }

    public Appointment() { }
}

