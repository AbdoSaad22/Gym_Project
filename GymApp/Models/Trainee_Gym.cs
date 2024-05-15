namespace GymApp.Models
{
    public class Trainee_Gym
    {
        public string TraineeId { get; set; }

        public Trainee Trainee { get; set; }
        public int GymId { get; set; }

        public Gym Gym { get; set; }

    }
}
