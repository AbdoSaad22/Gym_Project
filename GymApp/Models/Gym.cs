using System.Data;

namespace GymApp.Models
{
    public class Gym
    {
        public int GymId { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public int subscribtionFees { get; set; }
        public Owner Owner { get; set; }
        public string OwnerId { get; set; }
        public IList<Coach_Gym> Coach_Gyms { get; set; }
        public IList<Trainee_Gym> Trainee_Gyms { get; set; }
    }
}
