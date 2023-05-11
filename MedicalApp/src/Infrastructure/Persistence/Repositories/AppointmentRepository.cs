using Application.Abstract.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        private readonly MedicalAppDbContext _medicalAppDbContext;
        private readonly DbSet<Appointment> _appointments;
        public AppointmentRepository(MedicalAppDbContext medicalAppDbContext) : base(medicalAppDbContext)
        {
            _medicalAppDbContext = medicalAppDbContext;
            _appointments = _medicalAppDbContext.Set<Appointment>();
        }

        public async Task<List<Appointment>> GetByDoctorIdAsync(int id)
        {
            return await _appointments
                .Include(a => a.Patient)
                .Where(a => a.DoctorId == id).ToListAsync();
        }

        public async Task<List<Appointment>> GetByPatientIdAsync(int id)
        {
            return await _appointments
                .Include(a => a.Doctor)
                .Where(a => a.PatientId == id).ToListAsync();
        }

        public async Task<bool> IsAppointmentDateExist(int doctorId, DateTime date)
        {
            return await _appointments
                  .AnyAsync(a => a.DoctorId == doctorId && a.AppointmentDate == date);
        }

        public override async Task<Appointment> GetByIdAsync(int id)
        {
            return await _appointments.Include(i => i.Patient)
               .Include(i => i.Doctor)
               .Where(i => i.Id == id).FirstOrDefaultAsync();
        }
    }
}
