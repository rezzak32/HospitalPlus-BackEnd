using Application.Abstract.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(MedicalAppDbContext medicalAppDbContext) : base(medicalAppDbContext)
        {

        }


    }
}
