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
public class AppointmentsUpdateController : AppointmentsController
{
    public AppointmentsUpdateController(IAppointmentRepository appointmentRepository) : base(appointmentRepository) { }

    // PUT: api/v1/appointments/{id}
    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Updates an appointment by ID",
        Description = "Updates a specific appointment in the system based on their ID"
    )]
    public async Task<IActionResult> UpdateAppointment(int id, [FromBody] AppointmentDTO appointmentDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var appointment = await _appointmentRepository.GetAppointmentById(id);
        if (appointment == null)
        {
            return NotFound("Appointment not found");
        }

        appointment.AppointmentDate = appointmentDto.AppointmentDate;
        appointment.Status = appointmentDto.Status;
        appointment.PatientId = appointmentDto.PatientId;
        appointment.DoctorId = appointmentDto.DoctorId;

        try
        {
            await _appointmentRepository.UpdateAppointment(appointment);
            return Ok(appointment);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}

