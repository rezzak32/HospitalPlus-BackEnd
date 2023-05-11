using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.ResponseModels
{
    public class LoginDoctorView
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Adress { get; set; }
        public string ProfessionName { get; set; } = null!;

        public string Bio { get; set; } = null!;

        public int Id { get; set; }

    }
}
