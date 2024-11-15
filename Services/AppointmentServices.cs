using MedSched.Data;
using MedSched.Models;
using MedSched.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MedSched.Services;

public class AppointmentServices : IAppointmentRepository
{
    private readonly AppDbContext _context;

    public AppointmentServices(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAppointment(Appointment appointment)
    {
        if (appointment == null)
        {
            throw new ArgumentNullException(nameof(appointment), "Appointment cannot be null");
        }

        try
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Failed to add appointment to the database", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Unexpected error while adding the appointment", ex);
        }
    }

    public async Task DeleteAppointment(int id)
    {
        var appointment = await _context.Appointments.FindAsync(id);
        if (appointment == null)
        {
            throw new ArgumentNullException(nameof(appointment), "Appointment not found");
        }
        else
        {
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctorId(int doctorId)
    {
        try
        {
            var appointments = await _context.Appointments.Where(a => a.DoctorId == doctorId).ToListAsync();
            return appointments;
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving appointments for the doctor", ex);
        }
    }

    public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientId(int patientId)
    {
        try
        {
            var appointments = await _context.Appointments.Where(a => a.PatientId == patientId).ToListAsync();
            return appointments;
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving appointments for the patient", ex);
        }
    }

    public async Task<Appointment> GetAppointmentById(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Id must be a positive integer", nameof(id));
        }

        try
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                throw new ArgumentNullException(nameof(appointment), "Appointment not found");
            }
            return appointment;
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving the appointment", ex);
        }
    }

    public async Task<IEnumerable<Appointment>> GetAllAppointments()
    {
        try
        {
            var appointments = await _context.Appointments.ToListAsync();
            return appointments;
        }
        catch (Exception ex)
        {
            throw new Exception("Error retrieving all appointments", ex);
        }
    }

    public Task UpdateAppointment(Appointment appointment)
    {
        if (appointment == null)
        {
            throw new ArgumentNullException(nameof(appointment), "Appointment cannot be null");
        }
        try
        {
            _context.Entry(appointment).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception("Failed to update appointment in the database", dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Error updating the appointment", ex);
        }
    }
}

