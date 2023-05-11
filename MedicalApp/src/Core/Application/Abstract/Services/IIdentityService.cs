

using Application.Models.RequestModels.Login;
using Application.Models.RequestModels.Register;
using Application.Models.ResponseModels;

namespace Application.Abstract.Services
{
    public interface IIdentityService
    {
        Task<Response> RegisterAsync(RegisterPatientRequest request);
        Task<GetOneResponse<LoginPatientView>> LoginAsPatientAsync(LoginRequest request);
        Task<GetOneResponse<LoginDoctorView>> LoginAsDoctorAsync(LoginRequest request);
    }
}
