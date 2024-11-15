using System.Linq.Expressions;
using MedSched.Data;
using MedSched.Models;
using MedSched.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MedSched.Services;

public class PatientServices : IPatientRepository
{
    private readonly AppDbContext _context;

    public PatientServices(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddPatient(Patient patient)
    {
        if (patient == null)
        {
            throw new ArgumentNullException(nameof(patient), "Patient cannot be null");
        }

        try
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Failed to add patient to the database", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error while adding the patient", ex);
        }
    }

    public async Task DeletePatient(int id)
    {
        var patient = await _context.Patients.FindAsync(id);
        if (patient == null)
        {
            throw new ArgumentNullException(nameof(patient), "Patient not found");
        }
        else
        {
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Patient>> GetAllPatients()
    {
        try
        {
            var patients = await _context.Patients.ToListAsync();
            return patients;
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving all patients", ex);
        }
    }

    public async Task<Patient> GetPatientById(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Id must be a positive integer", nameof(id));
        }

        try
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient), "Patient not found");
            }
            return patient;
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving the patient", ex);
        }
    }

    public Task UpdatePatient(Patient patient)
    {
        if (patient == null)
        {
            throw new ArgumentNullException(nameof(patient), "Patient cannot be null");
        }
        try
        {
            _context.Entry(patient).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Failed to update patient in the database", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error while updating the patient", ex);
        }
    }
}

