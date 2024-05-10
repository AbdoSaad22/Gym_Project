using System.ComponentModel.DataAnnotations;

namespace GymApp.Models
{
    public class User
    {
        [Key]
        public string SSN { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string type { get; set; }
    }
}
