using MedSched.Models;

namespace MedSched.Repositories;

public interface IPatientRepository
{
    Task<IEnumerable<Patient>> GetAllPatients();
    Task<Patient> GetPatientById(int id);
    Task AddPatient(Patient patient);
    Task UpdatePatient(Patient patient);
    Task DeletePatient(int id);
}

