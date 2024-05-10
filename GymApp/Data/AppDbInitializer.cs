using GymApp.Models;
using System.Collections.Specialized;

namespace GymApp.Data
{
    public class AppDbInitializer
    {
        public static void seed(AppDbContext context)
        {
            context.Database.EnsureCreated();
            //Cinema
            if (!context.Owners.Any())
            {
                context.Owners.AddRange(new List<Owner>()
                {
                    new Owner
                    {
                        name="abdo",
                        age=21,
                        password="a",
                        email="abdo",
                        SSN="123",
                        phoneNum="a",

                    }
                }) ;
                context.SaveChanges();
            }
            if (!context.Gym.Any())
            {
                context.Gym.AddRange(new List<Gym>()
                {
                    new Gym
                    {
                        name="hero",
                        
                        OwnerId="123",
                        location="assiut",
                        subscribtionFees=100,
                    }
                });
                context.SaveChanges();
            }
        }
    }
}
