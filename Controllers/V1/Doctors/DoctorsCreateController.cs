using MedSched.DTOs.Requests;
using MedSched.Models;
using MedSched.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedSched.Controllers.V1.Doctors;

[ApiController]
[Route("api/v1/doctors")]
[Tags("Doctors")]
public class DoctorsCreateController : DoctorsController
{
    public DoctorsCreateController(IDoctorRepository doctorRepository) : base(doctorRepository) { }

    // POST: api/v1/doctors
    [HttpPost]
    public async Task<IActionResult> AddDoctor([FromBody] DoctorDTO doctorDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var doctor = new Doctor
        {
            Name = doctorDto.Name,
            Specialization = doctorDto.Specialization,
            Availability = doctorDto.Availability
        };

        try
        {
            await _doctorRepository.AddDoctor(doctor);
            return Ok(doctor);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}

