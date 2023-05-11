using Application.Models.RequestModels.Appointment;
using Application.Models.RequestModels.Login;
using Application.Models.RequestModels.Register;
using Application.Models.ResponseModels;
using AutoMapper;
using Domain;

namespace Application.Mapper 
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterPatientRequest, Patient>();
            CreateMap<Doctor, GetDoctorResponse>();
            CreateMap<Patient, LoginPatientView>();
            CreateMap<Doctor, LoginDoctorView>();
            CreateMap<CreateAppointmentRequest, Appointment>();
        }
       
    }
}
