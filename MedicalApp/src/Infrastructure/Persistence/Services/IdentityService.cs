using Application.Abstract.Repositories;
using Application.Abstract.Services;
using Application.Models.RequestModels.Login;
using Application.Models.RequestModels.Register;
using Application.Models.ResponseModels;
using AutoMapper;
using Domain;

namespace Persistence.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IPatientRepository  _patientRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        public IdentityService(IPatientRepository patientRepository, IMapper mapper, IDoctorRepository  doctorRepository)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
            _doctorRepository = doctorRepository;
        }

        public async Task<Response> RegisterAsync(RegisterPatientRequest request)
        {
            var Patient = await _patientRepository.GetSingleAsync(u => u.Email == request.Email);

            if (Patient != null)
                return new Response { Message = "Kullanıcı zaten kayıtlı" };

            var dbPatient = _mapper.Map<Patient>(request);

            var result = await _patientRepository.AddAsync(dbPatient);

            await _patientRepository.SaveChangesAsync();

            if(!result)
                return new Response { Message = "Kullanıcı ekleme işleminde hata oluştu" };

            return new Response { Message = "Kullanıcı eklendi", Success = true};


        }

        public async Task<GetOneResponse<LoginPatientView>> LoginAsPatientAsync(LoginRequest request)
        {
            var patient = await _patientRepository.GetSingleAsync(i => i.Email == request.Email);

            if (patient is null)
                return new() { Message = "Kayıtlı kullanıcı bulunamadı" };

            if (patient.Password != request.Password)
                return new () { Message = "şifre hatalı" };

            var userView = _mapper.Map<LoginPatientView>(patient);

            return new() {Result = userView,  Success = true, Message = "giriş başarılı" };
        }

        public async Task<GetOneResponse<LoginDoctorView>> LoginAsDoctorAsync(LoginRequest request)
        {
            var doctor = await _doctorRepository.GetSingleAsync(i => i.Email == request.Email);

            if (doctor is null)
                return new() { Message = "Kayıtlı kullanıcı bulunamadı" };


            if (doctor.Password != request.Password)
                return new() { Message = "şifre hatalı" };

            var userView = _mapper.Map<LoginDoctorView>(doctor);

            return new() {Result = userView,Success = true, Message = "giriş başarılı" };
        }
    }
    }

