﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rovers4.Data;

namespace Rovers4.Migrations
{
    [DbContext(typeof(ClubContext))]
    partial class ClubContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Rovers4.Models.Club", b =>
                {
                    b.Property<int>("ClubID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("ClubID");

                    b.ToTable("Clubs");

                    b.HasData(
                        new
                        {
                            ClubID = 1,
                            Address = "Bushy Park",
                            Email = "X00152190@mytudublin.ie",
                            Name = "Ratharnham Rovers",
                            Number = "0872878566"
                        });
                });

            modelBuilder.Entity("Rovers4.Models.Fixture", b =>
                {
                    b.Property<int>("FixtureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FixtureDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FixtureType")
                        .HasColumnType("int");

                    b.Property<int>("HomeOrAway")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatchReport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeetLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MeetTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Opponent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OpponentScore")
                        .HasColumnType("int");

                    b.Property<int?>("OurScore")
                        .HasColumnType("int");

                    b.Property<int>("ResultDescription")
                        .HasColumnType("int");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FixtureID");

                    b.HasIndex("TeamID");

                    b.ToTable("Fixtures");
                });

            modelBuilder.Entity("Rovers4.Models.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MgmtRole")
                        .HasColumnType("int");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonType")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerPosition")
                        .HasColumnType("int");

                    b.Property<int>("PlayerStatID")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerStatID1")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<int?>("TeamID")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonID");

                    b.HasIndex("PlayerStatID1");

                    b.HasIndex("TeamID");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            PersonID = 1,
                            FirstName = "Ronan",
                            PersonType = 0,
                            PlayerPosition = 1,
                            PlayerStatID = 0,
                            Surname = "Breen",
                            TeamName = "First Team"
                        },
                        new
                        {
                            PersonID = 2,
                            FirstName = "Ronan",
                            PersonType = 0,
                            PlayerPosition = 0,
                            PlayerStatID = 0,
                            Surname = "Grey",
                            TeamName = "First Team"
                        },
                        new
                        {
                            PersonID = 3,
                            FirstName = "Richard",
                            PersonType = 0,
                            PlayerPosition = 2,
                            PlayerStatID = 0,
                            Surname = "Breen",
                            TeamName = "First Team"
                        },
                        new
                        {
                            PersonID = 4,
                            FirstName = "Andrew",
                            PersonType = 0,
                            PlayerPosition = 3,
                            PlayerStatID = 0,
                            Surname = "Breen",
                            TeamName = "First Team"
                        },
                        new
                        {
                            PersonID = 5,
                            FirstName = "Murray",
                            PersonType = 0,
                            PlayerPosition = 1,
                            PlayerStatID = 0,
                            Surname = "Breen",
                            TeamName = "First Team"
                        },
                        new
                        {
                            PersonID = 6,
                            FirstName = "Patricia",
                            PersonType = 0,
                            PlayerPosition = 0,
                            PlayerStatID = 0,
                            Surname = "Breen",
                            TeamName = "First Team"
                        },
                        new
                        {
                            PersonID = 7,
                            FirstName = "Elmond",
                            MgmtRole = 0,
                            PersonType = 1,
                            PlayerStatID = 0,
                            Surname = "Breen",
                            TeamName = "First Team"
                        },
                        new
                        {
                            PersonID = 8,
                            FirstName = "Tim",
                            PersonType = 0,
                            PlayerPosition = 0,
                            PlayerStatID = 0,
                            Surname = "Breen",
                            TeamName = "Under 21s"
                        },
                        new
                        {
                            PersonID = 9,
                            FirstName = "Tom",
                            PersonType = 0,
                            PlayerPosition = 1,
                            PlayerStatID = 0,
                            Surname = "Grey",
                            TeamName = "Under 21s"
                        },
                        new
                        {
                            PersonID = 10,
                            FirstName = "Trevor",
                            PersonType = 0,
                            PlayerPosition = 2,
                            PlayerStatID = 0,
                            Surname = "Breen",
                            TeamName = "Under 21s"
                        },
                        new
                        {
                            PersonID = 11,
                            FirstName = "Tilly",
                            PersonType = 0,
                            PlayerPosition = 3,
                            PlayerStatID = 0,
                            Surname = "Breen",
                            TeamName = "Under 19s"
                        },
                        new
                        {
                            PersonID = 12,
                            FirstName = "Tyrance",
                            PersonType = 0,
                            PlayerPosition = 0,
                            PlayerStatID = 0,
                            Surname = "Breen",
                            TeamName = "Under 19s"
                        },
                        new
                        {
                            PersonID = 13,
                            FirstName = "Tombo",
                            PersonType = 0,
                            PlayerPosition = 1,
                            PlayerStatID = 0,
                            Surname = "Breen",
                            TeamName = "Under 19s"
                        },
                        new
                        {
                            PersonID = 14,
                            FirstName = "Timo",
                            PersonType = 1,
                            PlayerPosition = 3,
                            PlayerStatID = 0,
                            Surname = "Breen",
                            TeamName = "Under 19s"
                        });
                });

            modelBuilder.Entity("Rovers4.Models.PlayerStat", b =>
                {
                    b.Property<int>("PlayerStatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Assists")
                        .HasColumnType("int");

                    b.Property<int>("CleanSheet")
                        .HasColumnType("int");

                    b.Property<int>("GamesPlayed")
                        .HasColumnType("int");

                    b.Property<int>("Goals")
                        .HasColumnType("int");

                    b.Property<int>("MotmAward")
                        .HasColumnType("int");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.Property<int>("RedCards")
                        .HasColumnType("int");

                    b.HasKey("PlayerStatID");

                    b.ToTable("PlayerStats");

                    b.HasData(
                        new
                        {
                            PlayerStatID = 1,
                            Assists = 5,
                            CleanSheet = 0,
                            GamesPlayed = 5,
                            Goals = 3,
                            MotmAward = 3,
                            PersonID = 1,
                            RedCards = 2
                        },
                        new
                        {
                            PlayerStatID = 2,
                            Assists = 1,
                            CleanSheet = 0,
                            GamesPlayed = 3,
                            Goals = 1,
                            MotmAward = 1,
                            PersonID = 2,
                            RedCards = 0
                        },
                        new
                        {
                            PlayerStatID = 3,
                            Assists = 2,
                            CleanSheet = 0,
                            GamesPlayed = 2,
                            Goals = 2,
                            MotmAward = 2,
                            PersonID = 3,
                            RedCards = 2
                        },
                        new
                        {
                            PlayerStatID = 4,
                            Assists = 5,
                            CleanSheet = 0,
                            GamesPlayed = 3,
                            Goals = 3,
                            MotmAward = 3,
                            PersonID = 4,
                            RedCards = 2
                        },
                        new
                        {
                            PlayerStatID = 5,
                            Assists = 5,
                            CleanSheet = 0,
                            GamesPlayed = 5,
                            Goals = 3,
                            MotmAward = 3,
                            PersonID = 5,
                            RedCards = 2
                        },
                        new
                        {
                            PlayerStatID = 6,
                            Assists = 5,
                            CleanSheet = 0,
                            GamesPlayed = 5,
                            Goals = 3,
                            MotmAward = 3,
                            PersonID = 6,
                            RedCards = 2
                        },
                        new
                        {
                            PlayerStatID = 7,
                            Assists = 5,
                            CleanSheet = 0,
                            GamesPlayed = 5,
                            Goals = 3,
                            MotmAward = 3,
                            PersonID = 7,
                            RedCards = 2
                        },
                        new
                        {
                            PlayerStatID = 8,
                            Assists = 5,
                            CleanSheet = 0,
                            GamesPlayed = 5,
                            Goals = 3,
                            MotmAward = 3,
                            PersonID = 8,
                            RedCards = 2
                        },
                        new
                        {
                            PlayerStatID = 9,
                            Assists = 5,
                            CleanSheet = 0,
                            GamesPlayed = 5,
                            Goals = 3,
                            MotmAward = 3,
                            PersonID = 9,
                            RedCards = 2
                        },
                        new
                        {
                            PlayerStatID = 10,
                            Assists = 5,
                            CleanSheet = 0,
                            GamesPlayed = 5,
                            Goals = 3,
                            MotmAward = 3,
                            PersonID = 10,
                            RedCards = 2
                        },
                        new
                        {
                            PlayerStatID = 11,
                            Assists = 5,
                            CleanSheet = 0,
                            GamesPlayed = 5,
                            Goals = 3,
                            MotmAward = 3,
                            PersonID = 11,
                            RedCards = 2
                        },
                        new
                        {
                            PlayerStatID = 12,
                            Assists = 5,
                            CleanSheet = 0,
                            GamesPlayed = 5,
                            Goals = 3,
                            MotmAward = 3,
                            PersonID = 12,
                            RedCards = 2
                        },
                        new
                        {
                            PlayerStatID = 13,
                            Assists = 5,
                            CleanSheet = 0,
                            GamesPlayed = 5,
                            Goals = 3,
                            MotmAward = 3,
                            PersonID = 13,
                            RedCards = 2
                        },
                        new
                        {
                            PlayerStatID = 14,
                            Assists = 5,
                            CleanSheet = 0,
                            GamesPlayed = 5,
                            Goals = 3,
                            MotmAward = 3,
                            PersonID = 14,
                            RedCards = 2
                        });
                });

            modelBuilder.Entity("Rovers4.Models.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClubID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamID");

                    b.HasIndex("ClubID");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            TeamID = 1,
                            ClubID = 1,
                            Name = "First Team"
                        },
                        new
                        {
                            TeamID = 2,
                            ClubID = 1,
                            Name = "Under 21s"
                        },
                        new
                        {
                            TeamID = 3,
                            ClubID = 1,
                            Name = "Under 19s"
                        },
                        new
                        {
                            TeamID = 4,
                            ClubID = 1,
                            Name = "Under 17s"
                        },
                        new
                        {
                            TeamID = 5,
                            ClubID = 1,
                            Name = "Under 15s"
                        },
                        new
                        {
                            TeamID = 6,
                            ClubID = 1,
                            Name = "Under 13s"
                        },
                        new
                        {
                            TeamID = 7,
                            ClubID = 1,
                            Name = "Under 11s"
                        });
                });

            modelBuilder.Entity("Rovers4.Models.Fixture", b =>
                {
                    b.HasOne("Rovers4.Models.Team", "Team")
                        .WithMany("fixtures")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Rovers4.Models.Person", b =>
                {
                    b.HasOne("Rovers4.Models.PlayerStat", "PlayerStat")
                        .WithMany()
                        .HasForeignKey("PlayerStatID1");

                    b.HasOne("Rovers4.Models.Team", "Team")
                        .WithMany("Staff")
                        .HasForeignKey("TeamID");
                });

            modelBuilder.Entity("Rovers4.Models.Team", b =>
                {
                    b.HasOne("Rovers4.Models.Club", "Club")
                        .WithMany()
                        .HasForeignKey("ClubID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
