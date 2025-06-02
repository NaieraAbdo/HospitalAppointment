using HospitalAppointment.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointment.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source = .; Initial Catalog= HospitalAppointment; Integrated Security= True;  TrustServerCertificate=True;");
        }
    }
}
