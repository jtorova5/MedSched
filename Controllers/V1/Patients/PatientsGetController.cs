using MedSched.Models;
using MedSched.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MedSched.Controllers.V1.Patients;

[ApiController]
[Route("api/v1/patients")]
[Tags("Patients")]
public class PatientsGetController : PatientsController
{
    public PatientsGetController(IPatientRepository patientRepository) : base(patientRepository) { }

    // GET: api/v1/patients/{id}
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Retrieves a patient by ID",
        Description = "Retrieves a specific patient from the system based on their ID"
    )]
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
    [SwaggerOperation(
        Summary = "Retrieves all patients",
        Description = "Retrieves all patients from the system"
    )]
    public async Task<IActionResult> GetAllPatients()
    {
        var patients = await _patientRepository.GetAllPatients();
        return Ok(patients);
    }
}
