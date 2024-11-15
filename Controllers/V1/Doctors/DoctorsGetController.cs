using MedSched.Models;
using MedSched.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MedSched.Controllers.V1.Doctors
{
    [ApiController]
    [Route("api/v1/doctors")]
    [Tags("Doctors")]
    public class DoctorsGetController : DoctorsController
    {
        public DoctorsGetController(IDoctorRepository doctorRepository) : base(doctorRepository) { }

        // GET: api/v1/doctors/{id}
        [HttpGet("{id}")]
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
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _doctorRepository.GetAllDoctors();
            return Ok(doctors);
        }
    }
}
