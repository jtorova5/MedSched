using MedSched.Models;
using MedSched.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedSched.Controllers.V1.Doctors;

[ApiController]
[Route("api/v1/doctors")]
[Tags("Doctors")]
public class DoctorsDeleteController : DoctorsController
{
    public DoctorsDeleteController(IDoctorRepository doctorRepository) : base(doctorRepository) { }

    // DELETE: api/v1/doctors/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDoctor(int id)
    {
        var doctor = await _doctorRepository.GetDoctorById(id);
        if (doctor == null)
        {
            return NotFound("Doctor not found");
        }

        try
        {
            await _doctorRepository.DeleteDoctor(id);
            return Ok($"Doctor with ID {id} has been deleted");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}

