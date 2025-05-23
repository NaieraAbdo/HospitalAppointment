using HospitalAppointment.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointment.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source = .; Initial Catalog= HospitalAppointment; Integerated Security= True; TrustedServerCertificate = True;");
        }
    }
}
