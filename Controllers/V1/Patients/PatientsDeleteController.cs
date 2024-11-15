using MedSched.Models;
using MedSched.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace MedSched.Controllers.V1.Patients;

[ApiController]
[Route("api/v1/patients")]
[Tags("Patients")]
public class PatientsDeleteController : PatientsController
{
    public PatientsDeleteController(IPatientRepository patientRepository) : base(patientRepository) { }

    // DELETE: api/v1/patients/{id}
    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Removes a patient by ID",
        Description = "Removes a specific patient from the system based on their ID"
    )]
    public async Task<IActionResult> DeletePatient(int id)
    {
        var patient = await _patientRepository.GetPatientById(id);
        if (patient == null)
        {
            return NotFound("Patient not found");
        }

        try
        {
            await _patientRepository.DeletePatient(id);
            return Ok($"Patient with ID {id} has been deleted");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
