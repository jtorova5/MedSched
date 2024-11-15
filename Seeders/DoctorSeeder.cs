using Microsoft.EntityFrameworkCore;
using MedSched.Models;

namespace MedSched.Seeders;

public class DoctorSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>().HasData(
            new Doctor
            {
                Id = 1,
                Name = "Dr. John Doe",
                Specialization = "Cardiologist",
                Availability = true,
                Email = "doc1@example.com",
                Password = "123"
            },
            new Doctor
            {
                Id = 2,
                Name = "Dr. Jane Smith",
                Specialization = "Neurologist",
                Availability = true,
                Email = "doc2@example.com",
                Password = "123"
            },
            new Doctor
            {
                Id = 3,
                Name = "Dr. Emily Brown",
                Specialization = "Dermatologist",
                Availability = false,
                Email = "doc3@example.com",
                Password = "123"
            },
            new Doctor
            {
                Id = 4,
                Name = "Dr. Michael Johnson",
                Specialization = "Orthopedist",
                Availability = true,
                Email = "doc4@example.com",
                Password = "123"
            },
            new Doctor
            {
                Id = 5,
                Name = "Dr. Sarah Lee",
                Specialization = "Pediatrician",
                Availability = true,
                Email = "doc5@example.com",
                Password = "123"
            },
            new Doctor
            {
                Id = 6,
                Name = "Dr. Robert White",
                Specialization = "General Surgeon",
                Availability = true,
                Email = "doc6@example.com",
                Password = "123"
            },
            new Doctor
            {
                Id = 7,
                Name = "Dr. Olivia Harris",
                Specialization = "Psychiatrist",
                Availability = true,
                Email = "doc7@example.com",
                Password = "123"
            },
            new Doctor
            {
                Id = 8,
                Name = "Dr. William Clark",
                Specialization = "Gastroenterologist",
                Availability = false,
                Email = "doc8@example.com",
                Password = "123"
            },
            new Doctor
            {
                Id = 9,
                Name = "Dr. Patricia Lewis",
                Specialization = "Gynecologist",
                Availability = true,
                Email = "doc9@example.com",
                Password = "123"
            },
            new Doctor
            {
                Id = 10,
                Name = "Dr. James Walker",
                Specialization = "Anesthesiologist",
                Availability = true,
                Email = "doc10@example.com",
                Password = "123"
            }
        );
    }
}
