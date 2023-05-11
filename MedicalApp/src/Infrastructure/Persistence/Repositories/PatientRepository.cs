

using Application.Abstract.Repositories;
using Domain;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(MedicalAppDbContext medicalAppDbContext) : base(medicalAppDbContext)
        {
        }
    }
}
