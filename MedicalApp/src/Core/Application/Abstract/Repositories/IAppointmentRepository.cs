using Application.Models.RequestModels.Appointment;
using Application.Models.ResponseModels;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstract.Repositories
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        Task<List<Appointment>> GetByPatientIdAsync(int id);    
        Task<List<Appointment>> GetByDoctorIdAsync(int id);

        Task<bool> IsAppointmentDateExist(int doctorId, DateTime date);

    }
}
    