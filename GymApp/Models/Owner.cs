using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymApp.Models
{
    public class Owner
    {
        [Key]
        public string SSN { get; set; }
        public string name { get; set; }
        public string phoneNum { get; set; }
        public string email { get; set; }
        public string password { get; set; }
       
        public int age { get; set; }
        public string? imagePath { get; set; }

        [NotMapped]

        public IFormFile clientfile { get; set; }
        public byte[]? dbImage { get; set; }

        [NotMapped]
        public string? imageSrc
        {
            get
            {
                if (dbImage != null)
                {
                    string base64String = Convert.ToBase64String(dbImage, 0, dbImage.Length);
                    return "data:image/jpg;base64," + base64String;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public IList<Gym> Gyms { get; set; }
    }
}
