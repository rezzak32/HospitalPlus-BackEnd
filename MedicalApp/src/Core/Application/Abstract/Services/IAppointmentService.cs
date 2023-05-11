using Application.Models.RequestModels.Appointment;
using Application.Models.ResponseModels;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstract.Services
{
    public interface IAppointmentService
    {
        Task<Response> CreateAsync(CreateAppointmentRequest request);
        Task<GetOneResponse<Appointment>> GetByIdAsync(int id);

        Task<GetManyResponse<Appointment>> GetAllByPatientIdAsync(int patientId);
        Task<GetManyResponse<Appointment>> GetAllByDoctorIdAsync(int patientId);
    }
}
