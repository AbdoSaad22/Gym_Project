namespace GymApp.Models
{
    public class Coach_Gym
    {
        public string CoachId { get; set; }
        
        public Coach Coach{get;set;}
        public int GymId { get; set; }

        public Gym Gym { get; set; }

    }
}
