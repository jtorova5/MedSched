using MedSched.DTOs.Requests;
using MedSched.Models;
using MedSched.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MedSched.Controllers.V1.Appointments;

[ApiController]
[Route("api/v1/appointments")]
[Tags("Appointments")]
[Authorize]
public class AppointmentsCreateController : AppointmentsController
{
    public AppointmentsCreateController(IAppointmentRepository appointmentRepository) : base(appointmentRepository) { }

    // POST: api/v1/appointments
    [HttpPost]
    [SwaggerOperation(
        Summary = "Adds a new appointment",
        Description = "Adds a new appointment to the system"
    )]
    public async Task<IActionResult> AddAppointment([FromBody] AppointmentDTO appointmentDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var appointment = new Appointment
        {
            AppointmentDate = appointmentDto.AppointmentDate,
            Status = appointmentDto.Status,
            PatientId = appointmentDto.PatientId,
            DoctorId = appointmentDto.DoctorId
        };

        try
        {
            await _appointmentRepository.AddAppointment(appointment);
            return Ok(appointment);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}

