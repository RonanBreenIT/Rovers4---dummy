﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rovers4.Data;

namespace Rovers4.Migrations
{
    [DbContext(typeof(ClubContext))]
    [Migration("20200923171524_MigrationName")]
    partial class MigrationName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
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

                    b.Property<string>("ClubImage1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClubImage2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClubImage3")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<string>("PersonBio")
                        .HasColumnType("nvarchar(1280)")
                        .HasMaxLength(1280);

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

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.Property<string>("ThumbnailImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonID");

                    b.HasIndex("PlayerStatID1");

                    b.HasIndex("TeamID");

                    b.ToTable("Persons");
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
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("TeamBio")
                        .HasColumnType("nvarchar(1280)")
                        .HasMaxLength(1280);

                    b.Property<string>("TeamImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamID");

                    b.HasIndex("ClubID");

                    b.ToTable("Teams");
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
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
