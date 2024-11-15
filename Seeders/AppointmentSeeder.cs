using Microsoft.EntityFrameworkCore;
using MedSched.Models;

namespace MedSched.Seeders;

public class AppointmentSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>().HasData(
            new Appointment
            {
                Id = 1,
                AppointmentDate = new DateTime(2024, 11, 20, 9, 0, 0), // 20 de Noviembre de 2024 a las 09:00
                Status = "Scheduled",
                PatientId = 1,
                DoctorId = 1
            },
            new Appointment
            {
                Id = 2,
                AppointmentDate = new DateTime(2024, 11, 21, 10, 0, 0), // 21 de Noviembre de 2024 a las 10:00
                Status = "Scheduled",
                PatientId = 2,
                DoctorId = 2
            },
            new Appointment
            {
                Id = 3,
                AppointmentDate = new DateTime(2024, 11, 22, 11, 0, 0), // 22 de Noviembre de 2024 a las 11:00
                Status = "Scheduled",
                PatientId = 3,
                DoctorId = 1
            },
            new Appointment
            {
                Id = 4,
                AppointmentDate = new DateTime(2024, 11, 23, 14, 30, 0), // 23 de Noviembre de 2024 a las 14:30
                Status = "Completed",
                PatientId = 4,
                DoctorId = 3
            },
            new Appointment
            {
                Id = 5,
                AppointmentDate = new DateTime(2024, 11, 24, 15, 0, 0), // 24 de Noviembre de 2024 a las 15:00
                Status = "Scheduled",
                PatientId = 5,
                DoctorId = 2
            },
            new Appointment
            {
                Id = 6,
                AppointmentDate = new DateTime(2024, 11, 25, 16, 0, 0), // 25 de Noviembre de 2024 a las 16:00
                Status = "Scheduled",
                PatientId = 6,
                DoctorId = 1
            },
            new Appointment
            {
                Id = 7,
                AppointmentDate = new DateTime(2024, 11, 26, 9, 30, 0), // 26 de Noviembre de 2024 a las 09:30
                Status = "Scheduled",
                PatientId = 7,
                DoctorId = 3
            },
            new Appointment
            {
                Id = 8,
                AppointmentDate = new DateTime(2024, 11, 27, 12, 0, 0), // 27 de Noviembre de 2024 a las 12:00
                Status = "Completed",
                PatientId = 8,
                DoctorId = 2
            },
            new Appointment
            {
                Id = 9,
                AppointmentDate = new DateTime(2024, 11, 28, 13, 30, 0), // 28 de Noviembre de 2024 a las 13:30
                Status = "Scheduled",
                PatientId = 9,
                DoctorId = 1
            },
            new Appointment
            {
                Id = 10,
                AppointmentDate = new DateTime(2024, 11, 29, 8, 30, 0), // 29 de Noviembre de 2024 a las 08:30
                Status = "Canceled",
                PatientId = 10,
                DoctorId = 3
            }
        );
    }
}

