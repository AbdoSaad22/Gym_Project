using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using GymApp.Models;
using Microsoft.Data.SqlClient;
namespace GymApp.Data
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coach_Gym>().HasKey(cg => new
            {
                cg.CoachId,
                cg.GymId
            });

            modelBuilder.Entity<Coach_Gym>()
                .HasOne(c => c.Coach)
                .WithMany(cg => cg.Coach_Gyms).HasForeignKey(c => c.CoachId);
            modelBuilder.Entity<Coach_Gym>()
              .HasOne(g => g.Gym)
              .WithMany(c => c.Coach_Gyms).HasForeignKey(g => g.GymId);


            modelBuilder.Entity<Trainee_Gym>().HasKey(cg => new
            {
                cg.TraineeId,
                cg.GymId
            });

            modelBuilder.Entity<Trainee_Gym>()
                .HasOne(t => t.Trainee)
                .WithMany(tg => tg.Trainee_Gyms).HasForeignKey(t => t.TraineeId);
            modelBuilder.Entity<Trainee_Gym>()
              .HasOne(g => g.Gym)
              .WithMany(t => t.Trainee_Gyms).HasForeignKey(g => g.GymId);
        }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Owner> Owners { get; set; }

        public DbSet<Coach> Coachs { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Coach_Gym> Coach_Gyms { get; set; }
        public DbSet<Trainee_Gym> Trainee_Gyms { get; set; }

        public DbSet<Gym> Gym { get; set; }


    }

}
