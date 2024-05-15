using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymApp.Models
{
    public class Trainee
    {
        [Key]
        public string SSN { get; set; }
        public string name { get; set; }
        public string phoneNum { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime birthday { get; set; }
        public int age { get; set; }
        public string? imagePath { get; set; }

        [NotMapped]

        public IFormFile clientfile { get; set; }
        public IList<Trainee_Gym> Trainee_Gyms { get; set; }
    }
}
