

namespace Application.Models.ResponseModels
{
    public class GetDoctorResponse
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;     
        public string? Adress { get; set; }
        public string ProfessionName { get; set; } = null!;

        public string Bio { get; set; } = null!;

        public int Id { get; set; } 
    }
}
