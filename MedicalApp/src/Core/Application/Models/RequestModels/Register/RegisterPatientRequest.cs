

using System.ComponentModel.DataAnnotations;

namespace Application.Models.RequestModels.Register
{
    public class RegisterPatientRequest
    {
        public string FirstName { get; set; } = null!;

        [StringLength(20)]
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;

        [StringLength(20)]
        public string Password { get; set; } = null!;
        public string? Adress { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
