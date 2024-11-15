using MedSched.Models;
using MedSched.Seeders;
using Microsoft.EntityFrameworkCore;

namespace MedSched.Data;

public class AppDbContext : DbContext
{
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        AppointmentSeeder.Seed(modelBuilder);
        DoctorSeeder.Seed(modelBuilder);
        PatientSeeder.Seed(modelBuilder);
    }
}
