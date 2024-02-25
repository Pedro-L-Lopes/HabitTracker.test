﻿// <auto-generated />
using System;
using HabitTracker.test.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HabitTracker.test.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240225014526_DeleteOnCascade")]
    partial class DeleteOnCascade
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HabitTracker.test.Models.Day", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Date")
                        .IsUnique();

                    b.ToTable("Days");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("HabitTracker.test.Models.DayHabit", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("DayId")
                        .HasColumnType("int");

                    b.Property<int?>("HabitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DayId");

                    b.HasIndex("HabitId");

                    b.ToTable("DayHabits");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DayId = 1,
                            HabitId = 1
                        },
                        new
                        {
                            Id = 2,
                            DayId = 2,
                            HabitId = 1
                        },
                        new
                        {
                            Id = 3,
                            DayId = 3,
                            HabitId = 1
                        },
                        new
                        {
                            Id = 4,
                            DayId = 3,
                            HabitId = 2
                        });
                });

            modelBuilder.Entity("HabitTracker.test.Models.Habit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedAt");

                    b.ToTable("Habits");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Beber 2L água"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Exercitar"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Dormir 8h"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Ler 30 minutos"
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Meditar"
                        });
                });

            modelBuilder.Entity("HabitTracker.test.Models.HabitWeekDays", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("HabitId")
                        .HasColumnType("int");

                    b.Property<int?>("WeekDay")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HabitId");

                    b.ToTable("HabitWeekDays");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HabitId = 1,
                            WeekDay = 1
                        },
                        new
                        {
                            Id = 2,
                            HabitId = 1,
                            WeekDay = 2
                        },
                        new
                        {
                            Id = 3,
                            HabitId = 1,
                            WeekDay = 3
                        },
                        new
                        {
                            Id = 4,
                            HabitId = 2,
                            WeekDay = 3
                        },
                        new
                        {
                            Id = 5,
                            HabitId = 2,
                            WeekDay = 4
                        },
                        new
                        {
                            Id = 6,
                            HabitId = 2,
                            WeekDay = 5
                        },
                        new
                        {
                            Id = 7,
                            HabitId = 3,
                            WeekDay = 1
                        },
                        new
                        {
                            Id = 8,
                            HabitId = 3,
                            WeekDay = 2
                        },
                        new
                        {
                            Id = 9,
                            HabitId = 3,
                            WeekDay = 3
                        },
                        new
                        {
                            Id = 10,
                            HabitId = 3,
                            WeekDay = 4
                        },
                        new
                        {
                            Id = 11,
                            HabitId = 3,
                            WeekDay = 5
                        },
                        new
                        {
                            Id = 12,
                            HabitId = 4,
                            WeekDay = 1
                        },
                        new
                        {
                            Id = 13,
                            HabitId = 4,
                            WeekDay = 2
                        },
                        new
                        {
                            Id = 14,
                            HabitId = 5,
                            WeekDay = 4
                        },
                        new
                        {
                            Id = 15,
                            HabitId = 5,
                            WeekDay = 5
                        });
                });

            modelBuilder.Entity("HabitTracker.test.Models.DayHabit", b =>
                {
                    b.HasOne("HabitTracker.test.Models.Day", "Day")
                        .WithMany("DayHabits")
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HabitTracker.test.Models.Habit", "Habit")
                        .WithMany("DayHabits")
                        .HasForeignKey("HabitId");

                    b.Navigation("Day");

                    b.Navigation("Habit");
                });

            modelBuilder.Entity("HabitTracker.test.Models.HabitWeekDays", b =>
                {
                    b.HasOne("HabitTracker.test.Models.Habit", "Habit")
                        .WithMany("WeekDays")
                        .HasForeignKey("HabitId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Habit");
                });

            modelBuilder.Entity("HabitTracker.test.Models.Day", b =>
                {
                    b.Navigation("DayHabits");
                });

            modelBuilder.Entity("HabitTracker.test.Models.Habit", b =>
                {
                    b.Navigation("DayHabits");

                    b.Navigation("WeekDays");
                });
#pragma warning restore 612, 618
        }
    }
}
