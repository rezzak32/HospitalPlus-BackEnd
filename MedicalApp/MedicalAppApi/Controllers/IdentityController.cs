using Application.Abstract.Services;
using Application.Models.RequestModels.Login;
using Application.Models.RequestModels.Register;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register(RegisterPatientRequest request)
        {
            var result = await _identityService.RegisterAsync(request);

            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [HttpPost("/loginPatient")]
        public async Task<IActionResult> LoginPatient(LoginRequest request)
        {
            var result = await _identityService.LoginAsPatientAsync(request);

            return result.Success == true ? Ok(result) : BadRequest(result);

        }

        [HttpPost("/loginDoctor")]
        public async Task<IActionResult> LoginDoctor(LoginRequest request)
        {
            var result = await _identityService.LoginAsDoctorAsync(request);

            return result.Success == true ? Ok(result) : BadRequest(result);
        }
    }
}
