using Microsoft.EntityFrameworkCore;
using MedSched.Models;

namespace MedSched.Seeders;

public class PatientSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>().HasData(
            new Patient
            {
                Id = 1,
                Name = "John Doe",
                Birthdate = new DateTime(1985, 5, 12),
                ContactNumber = "555-1234",
                Email = "user1@example.com",
                Password = "123"
            },
            new Patient
            {
                Id = 2,
                Name = "Jane Smith",
                Birthdate = new DateTime(1990, 8, 25),
                ContactNumber = "555-5678",
                Email = "user2@example.com",
                Password = "123"
            },
            new Patient
            {
                Id = 3,
                Name = "Emily Johnson",
                Birthdate = new DateTime(1979, 3, 30),
                ContactNumber = "555-8765",
                Email = "user3@example.com",
                Password = "123"
            },
            new Patient
            {
                Id = 4,
                Name = "Michael Brown",
                Birthdate = new DateTime(2000, 1, 14),
                ContactNumber = "555-4321",
                Email = "user4@example.com",
                Password = "123"
            },
            new Patient
            {
                Id = 5,
                Name = "Sarah Lee",
                Birthdate = new DateTime(1988, 11, 22),
                ContactNumber = "555-8763",
                Email = "user5@example.com",
                Password = "123"
            },
            new Patient
            {
                Id = 6,
                Name = "Robert White",
                Birthdate = new DateTime(1995, 7, 17),
                ContactNumber = "555-1029",
                Email = "user6@example.com",
                Password = "123"
            },
            new Patient
            {
                Id = 7,
                Name = "Olivia Harris",
                Birthdate = new DateTime(1982, 6, 5),
                ContactNumber = "555-3245",
                Email = "user7@example.com",
                Password = "123"
            },
            new Patient
            {
                Id = 8,
                Name = "William Clark",
                Birthdate = new DateTime(1993, 9, 18),
                ContactNumber = "555-6543",
                Email = "user8@example.com",
                Password = "123"
            },
            new Patient
            {
                Id = 9,
                Name = "Patricia Lewis",
                Birthdate = new DateTime(1991, 12, 9),
                ContactNumber = "555-2345",
                Email = "user9@example.com",
                Password = "123"
            },
            new Patient
            {
                Id = 10,
                Name = "James Walker",
                Birthdate = new DateTime(1980, 4, 27),
                ContactNumber = "555-4329",
                Email = "user10@example.com",
                Password = "123"
            }
        );
    }
}
