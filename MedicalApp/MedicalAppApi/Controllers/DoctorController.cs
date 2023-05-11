using Application.Abstract.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Services;

namespace MedicalAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }


        [HttpGet("GetAll")]
        
        public async Task<IActionResult> GetAllDoctors()
        {
            var result = await _doctorService.ListAllAsync();

            return result.Success == true ? Ok(result) : BadRequest(result);
        }
    }

    }

