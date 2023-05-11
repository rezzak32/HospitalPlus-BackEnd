using Application.Abstract.Repositories;
using Application.Abstract.Services;
using Application.Models.ResponseModels;
using AutoMapper;

namespace Persistence.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<GetManyResponse<GetDoctorResponse>> ListAllAsync()
        {
            var dbDoctors = await _doctorRepository.GetAllAsync();

            var result = _mapper.Map<List<GetDoctorResponse>> (dbDoctors);

            return new() { Success = true, Result = result, Message = "İşlem başarılı" };

        }
    }
}
