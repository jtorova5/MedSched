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
public class AppointmentsDeleteController : AppointmentsController
{
    public AppointmentsDeleteController(IAppointmentRepository appointmentRepository) : base(appointmentRepository) { }

    // DELETE: api/v1/appointments/{id}
    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Removes an appointment by ID",
        Description = "Removes a specific appointment from the system based on their ID"
    )]
    public async Task<IActionResult> DeleteAppointment(int id)
    {
        var appointment = await _appointmentRepository.GetAppointmentById(id);
        if (appointment == null)
        {
            return NotFound("Appointment not found");
        }

        try
        {
            await _appointmentRepository.DeleteAppointment(id);
            return Ok($"Appointment with ID {id} has been deleted");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}

