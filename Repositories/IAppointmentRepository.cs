using MedSched.Models;

namespace MedSched.Repositories;

public interface IAppointmentRepository
{
    Task<IEnumerable<Appointment>> GetAllAppointments();
    Task<Appointment> GetAppointmentById(int id);
    Task<IEnumerable<Appointment>> GetAppointmentsByDoctorId(int doctorId);
    Task<IEnumerable<Appointment>> GetAppointmentsByPatientId(int patientId);
    Task AddAppointment(Appointment appointment);
    Task UpdateAppointment(Appointment appointment);
    Task DeleteAppointment(int id);
}

