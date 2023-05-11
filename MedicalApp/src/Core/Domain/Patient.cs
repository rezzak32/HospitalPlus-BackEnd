

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Patient : BaseEntity
    {
        public string FirstName { get; set; } = null!;

        [StringLength(20)]
        public string LastName { get; set; } = null!;

        [StringLength(20)]
        public string Email { get; set; } = null!;

        [StringLength(20)]
        public string Password { get; set; } = null!;
        [StringLength(50)]
        public string? Adress { get; set; }
        List<Appointment>? Appointments { get; set; }
    }
}
