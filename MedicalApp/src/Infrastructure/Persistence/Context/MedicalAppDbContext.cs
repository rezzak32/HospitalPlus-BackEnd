
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class MedicalAppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-FB5S5JH; Database=MedicalAppDatabase;uid=sa;pwd=1234;TrustServerCertificate=True");
        }
        public DbSet<Patient>? Patients { get; set; }
        public DbSet<Doctor>? Doctors { get; set; }
        public DbSet<Appointment>? Appointments { get; set; }

        internal Task<BaseEntity> FindAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
