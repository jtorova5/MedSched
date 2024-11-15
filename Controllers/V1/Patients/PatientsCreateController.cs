using MedSched.DTOs.Requests;
using MedSched.Models;
using MedSched.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MedSched.Controllers.V1.Patients;

[ApiController]
[Route("api/v1/patients")]
[Tags("Patients")]
public class PatientsCreateController : PatientsController
{
    public PatientsCreateController(IPatientRepository patientRepository) : base(patientRepository) { }

    // POST: api/v1/patients
    [HttpPost]
    [SwaggerOperation(
        Summary = "Adds a new patient",
        Description = "Adds a new patient to the system"
    )]
    public async Task<IActionResult> AddPatient([FromBody] PatientDTO patientDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var patient = new Patient
        {
            Name = patientDto.Name,
            Birthdate = patientDto.Birthdate,
            ContactNumber = patientDto.ContactNumber
        };

        try
        {
            await _patientRepository.AddPatient(patient);
            return Ok(patient);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}

