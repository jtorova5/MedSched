using MedSched.Models;
using MedSched.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MedSched.Controllers.V1.Doctors
{
    [ApiController]
    [Route("api/v1/doctors")]
    [Tags("Doctors")]
    [Authorize]
    public class DoctorsGetController : DoctorsController
    {
        public DoctorsGetController(IDoctorRepository doctorRepository) : base(doctorRepository) { }

        // GET: api/v1/doctors/{id}
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Retrieves a doctor by ID",
            Description = "Returns a specific doctor based on their ID"
        )]
        public async Task<IActionResult> GetDoctor(int id)
        {
            var doctor = await _doctorRepository.GetDoctorById(id);
            if (doctor == null)
            {
                return NotFound("Doctor not found");
            }

            return Ok(doctor);
        }

        // GET: api/v1/doctors
        [HttpGet]
        [SwaggerOperation(
            Summary = "Retrieves all doctors",
            Description = "Returns a list of all doctors"
        )]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _doctorRepository.GetAllDoctors();
            return Ok(doctors);
        }
    }
}
