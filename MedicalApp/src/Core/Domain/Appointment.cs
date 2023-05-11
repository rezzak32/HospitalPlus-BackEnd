

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Appointment : BaseEntity
    {
        public DateTime AppointmentDate { get; set; }
 
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;
        public  byte[]? SymptomPicture { get; set; }
    }
}
