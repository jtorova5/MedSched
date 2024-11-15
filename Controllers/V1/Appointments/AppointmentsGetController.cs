using MedSched.Models;
using MedSched.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MedSched.Controllers.V1.Appointments;

[ApiController]
[Route("api/v1/appointments")]
[Tags("Appointments")]
public class AppointmentsGetController : AppointmentsController
{
    public AppointmentsGetController(IAppointmentRepository appointmentRepository) : base(appointmentRepository) { }

    // GET: api/v1/appointments/{id}
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Retrieves an appointment by ID",
        Description = "Retrieves a specific appointment from the system based on their ID"
    )]
    public async Task<IActionResult> GetAppointment(int id)
    {
        var appointment = await _appointmentRepository.GetAppointmentById(id);
        if (appointment == null)
        {
            return NotFound("Appointment not found");
        }

        return Ok(appointment);
    }

    // GET: api/v1/appointments
    [HttpGet]
    [SwaggerOperation(
        Summary = "Retrieves all appointments",
        Description = "Retrieves all appointments from the system"
    )]
    public async Task<IActionResult> GetAllAppointments()
    {
        var appointments = await _appointmentRepository.GetAllAppointments();
        return Ok(appointments);
    }
}

