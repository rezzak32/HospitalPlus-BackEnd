

namespace Application.Models.RequestModels.Appointment
{
    public class CreateAppointmentRequest
    {
        public int PatientId { get; set; } 
        public int DoctorId { get; set; } 
        public byte[]? SymptomPicture { get; set; }
        public DateTime AppointmentDate { get; set; }

        
        
    }
}
