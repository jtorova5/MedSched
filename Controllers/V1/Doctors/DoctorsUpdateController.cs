using MedSched.DTOs.Requests;
using MedSched.Models;
using MedSched.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MedSched.Controllers.V1.Doctors;

[ApiController]
[Route("api/v1/doctors")]
[Tags("Doctors")]
public class DoctorsUpdateController : DoctorsController
{
    public DoctorsUpdateController(IDoctorRepository doctorRepository) : base(doctorRepository) { }

    // PUT: api/v1/doctors/{id}
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    [SwaggerOperation(
        Summary = "Updates a doctor by ID",
        Description = "Updates a specific doctor's information in the system based on their ID"
    )]
    public async Task<IActionResult> UpdateDoctor(int id, [FromBody] DoctorDTO doctorDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var doctor = await _doctorRepository.GetDoctorById(id);
        if (doctor == null)
        {
            return NotFound("Doctor not found");
        }

        doctor.Name = doctorDto.Name;
        doctor.Specialization = doctorDto.Specialization;
        doctor.Availability = doctorDto.Availability;

        try
        {
            await _doctorRepository.UpdateDoctor(doctor);
            return Ok(doctor);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}

