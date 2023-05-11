using Application.Abstract.Repositories;
using Application.Abstract.Services;
using Application.Models.RequestModels.Appointment;
using Application.Models.ResponseModels;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public AppointmentService(IPatientRepository patientRepository,
            IDoctorRepository doctorRepository,
            IMapper mapper,
            IAppointmentRepository appointmentRepository)
        {
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<Response> CreateAsync(CreateAppointmentRequest request)
        {
            var PatientId = await _patientRepository.GetSingleAsync(i => i.Id == request.PatientId);
            if (PatientId == null)
                return new()
                {
                    Message = "Böyle bir patientId bulunmuyor"
                };
            var Doctor = await _doctorRepository.GetSingleAsync(i => i.Id == request.DoctorId );
            if (Doctor == null )
                return new()
                {
                    Message = "Böyle bir doctorId bulunmuyor"
                };

            var appointmentExist = await _appointmentRepository.IsAppointmentDateExist(request.DoctorId, request.AppointmentDate);

            if (appointmentExist)
                return new() { Success = false, Message = "Bu tarih dolu" };


            var appointment = _mapper.Map<Appointment>(request);

            appointment.SymptomPicture = request.SymptomPicture;

            await _appointmentRepository.AddAsync(appointment);

            await _appointmentRepository.SaveChangesAsync();


            var patient = await _patientRepository.GetSingleAsync(i => i.Id == request.PatientId);

            await _patientRepository.SaveChangesAsync();

            return new() { Message="işlem başarılı", Success = true };


        }

        public async Task<GetManyResponse<Appointment>> GetAllByDoctorIdAsync(int doctorId)
        {
            var appointments = await _appointmentRepository.GetByDoctorIdAsync(doctorId);

            if (appointments == null)
                return new() { Success = false, Result = appointments, Message = "Herhangi bir randevu bulunamadı" };

            return new() { Result = appointments, Success = true };
        }

        public async Task<GetManyResponse<Appointment>> GetAllByPatientIdAsync(int patientId)
        {
            var appointments = await _appointmentRepository.GetByPatientIdAsync(patientId);

            if(appointments == null)
                return new() { Success = false, Result = appointments, Message = "Herhangi bir randevu bulunamadı" };

            return new() { Result = appointments, Success = true };
        }

        public async Task<GetOneResponse<Appointment>> GetByIdAsync(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);

            if (appointment is null)
            {
                return new() { Success = false, Message = "Herhangi bir randevu bulunamadı" };
            }

            return new() { Success = true, Result = appointment};

        }
    }
}
