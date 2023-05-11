

using Application.Models.ResponseModels;

namespace Application.Abstract.Services
{
    public interface IDoctorService
    {
        Task<GetManyResponse<GetDoctorResponse>> ListAllAsync();
    }
}
