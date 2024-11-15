using MedSched.DTOs.Requests;
using MedSched.Models;
using MedSched.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedSched.Controllers.V1.Patients;

[ApiController]
[Route("api/v1/patients")]
[Tags("Patients")]
public class PatientsUpdateController : PatientsController
{
    public PatientsUpdateController(IPatientRepository patientRepository) : base(patientRepository) { }

    // PUT: api/v1/patients/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePatient(int id, [FromBody] PatientDTO patientDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var patient = await _patientRepository.GetPatientById(id);
        if (patient == null)
        {
            return NotFound("Patient not found");
        }

        patient.Name = patientDto.Name;
        patient.Birthdate = patientDto.Birthdate;
        patient.ContactNumber = patientDto.ContactNumber;

        try
        {
            await _patientRepository.UpdatePatient(patient);
            return Ok(patient);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
