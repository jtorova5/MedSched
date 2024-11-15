using MedSched.Models;

namespace MedSched.Repositories;

public interface IDoctorRepository
{
    Task<IEnumerable<Doctor>> GetAllDoctors();
    Task<Doctor> GetDoctorById(int id);
    Task AddDoctor(Doctor doctor);
    Task UpdateDoctor(Doctor doctor);
    Task DeleteDoctor(int id);
}

