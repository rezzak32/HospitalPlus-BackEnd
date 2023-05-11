using Application.Abstract.Services;
using Application.Models.RequestModels.Appointment;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("CreateAppointment")]
        public async Task<IActionResult> CreateAppointment(CreateAppointmentRequest request)
        {
            var result = await _appointmentService.CreateAsync(request);

            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getByAppointmentId")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _appointmentService.GetByIdAsync(id);

            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getByPatientId")]
        public async Task<IActionResult> GetByPatientId(int id)
        {
            var result = await _appointmentService.GetAllByPatientIdAsync(id);

            return result.Success == true ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getByDoctorId")]
        public async Task<IActionResult> GetByDoctorId(int id)
        {
            var result = await _appointmentService.GetAllByDoctorIdAsync(id);

            return result.Success == true ? Ok(result) : BadRequest(result);
        }

    }
  
}
