﻿// <auto-generated />
using System;
using GymApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240428124854_addingModels")]
    partial class addingModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GymApp.Models.Coach", b =>
                {
                    b.Property<string>("SSN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<DateTime>("birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SSN");

                    b.ToTable("Coachs");
                });

            modelBuilder.Entity("GymApp.Models.Coach_Gym", b =>
                {
                    b.Property<string>("CoachId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("GymId")
                        .HasColumnType("int");

                    b.HasKey("CoachId", "GymId");

                    b.HasIndex("GymId");

                    b.ToTable("Coach_Gyms");
                });

            modelBuilder.Entity("GymApp.Models.Gym", b =>
                {
                    b.Property<int>("GymId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GymId"), 1L, 1);

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("subscribtionFees")
                        .HasColumnType("int");

                    b.Property<DateTime>("workingHours")
                        .HasColumnType("datetime2");

                    b.HasKey("GymId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Gym");
                });

            modelBuilder.Entity("GymApp.Models.Owner", b =>
                {
                    b.Property<string>("SSN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<DateTime>("birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SSN");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("GymApp.Models.Trainee", b =>
                {
                    b.Property<string>("SSN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<DateTime>("birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SSN");

                    b.ToTable("Trainees");
                });

            modelBuilder.Entity("GymApp.Models.Trainee_Gym", b =>
                {
                    b.Property<string>("TraineeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("GymId")
                        .HasColumnType("int");

                    b.HasKey("TraineeId", "GymId");

                    b.HasIndex("GymId");

                    b.ToTable("Trainee_Gyms");
                });

            modelBuilder.Entity("GymApp.Models.Coach_Gym", b =>
                {
                    b.HasOne("GymApp.Models.Coach", "Coach")
                        .WithMany("Coach_Gyms")
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymApp.Models.Gym", "Gym")
                        .WithMany("Coach_Gyms")
                        .HasForeignKey("GymId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coach");

                    b.Navigation("Gym");
                });

            modelBuilder.Entity("GymApp.Models.Gym", b =>
                {
                    b.HasOne("GymApp.Models.Owner", "Owner")
                        .WithMany("Gyms")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("GymApp.Models.Trainee_Gym", b =>
                {
                    b.HasOne("GymApp.Models.Gym", "Gym")
                        .WithMany("Trainee_Gyms")
                        .HasForeignKey("GymId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymApp.Models.Trainee", "Trainee")
                        .WithMany("Trainee_Gyms")
                        .HasForeignKey("TraineeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gym");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("GymApp.Models.Coach", b =>
                {
                    b.Navigation("Coach_Gyms");
                });

            modelBuilder.Entity("GymApp.Models.Gym", b =>
                {
                    b.Navigation("Coach_Gyms");

                    b.Navigation("Trainee_Gyms");
                });

            modelBuilder.Entity("GymApp.Models.Owner", b =>
                {
                    b.Navigation("Gyms");
                });

            modelBuilder.Entity("GymApp.Models.Trainee", b =>
                {
                    b.Navigation("Trainee_Gyms");
                });
#pragma warning restore 612, 618
        }
    }
}
