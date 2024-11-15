using MedSched.Models;
using MedSched.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MedSched.Controllers.V1.Patients;

[ApiController]
[Route("api/v1/patients")]
[Tags("Patients")]
public class PatientsGetController : PatientsController
{
    public PatientsGetController(IPatientRepository patientRepository) : base(patientRepository) { }

    // GET: api/v1/patients/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatient(int id)
    {
        var patient = await _patientRepository.GetPatientById(id);
        if (patient == null)
        {
            return NotFound("Patient not found");
        }

        return Ok(patient);
    }

    // GET: api/v1/patients
    [HttpGet]
    public async Task<IActionResult> GetAllPatients()
    {
        var patients = await _patientRepository.GetAllPatients();
        return Ok(patients);
    }
}
