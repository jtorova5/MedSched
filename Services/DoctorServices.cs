using MedSched.Data;
using MedSched.Models;
using MedSched.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MedSched.Services;

public class DoctorServices : IDoctorRepository
{
    private readonly AppDbContext _context;

    public DoctorServices(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddDoctor(Doctor doctor)
    {
        if (doctor == null)
        {
            throw new ArgumentNullException(nameof(doctor), "Doctor cannot be null");
        }

        try
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Failed to add doctor to the database", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error while adding the doctor", ex);
        }
    }

    public async Task DeleteDoctor(int id)
    {
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor == null)
        {
            throw new ArgumentNullException(nameof(doctor), "Doctor not found");
        }
        else
        {
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Doctor>> GetAllDoctors()
    {
        try
        {
            var doctors = await _context.Doctors.ToListAsync();
            return doctors;
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving all doctors", ex);
        }
    }

    public async Task<Doctor> GetDoctorById(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Id must be a positive integer", nameof(id));
        }

        try
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                throw new ArgumentNullException(nameof(doctor), "Doctor not found");
            }
            return doctor;
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving the doctor", ex);
        }
    }

    public Task UpdateDoctor(Doctor doctor)
    {
        if (doctor == null)
        {
            throw new ArgumentNullException(nameof(doctor), "Doctor cannot be null");
        }
        try
        {
            _context.Entry(doctor).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Failed to update doctor in the database", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error while updating the doctor", ex);
        }
    }
}
