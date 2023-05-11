using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace Domain
{
    public class Doctor : BaseEntity
    {
        [StringLength(20)]
        public string FirstName { get; set; } = null!;

        [StringLength(20)]
        public string LastName { get; set; } = null!;

        [StringLength(20)]
        public string Email { get; set; } = null!;

        [StringLength(20)]
        public string Password { get; set; } = null!;
        [StringLength(50)]
        public string? Adress { get; set; }
        [StringLength(30)]
        public string ProfessionName { get; set; } = null!;        
        public string Bio { get; set; } = null!;
        List<Appointment>? Appointments { get; set; }
    }
}
