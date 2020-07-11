using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rovers4.Models;

namespace Rovers4.Data
{
    public class ClubContext : DbContext
    {
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Team> Teams { get; set; }

        //public DbSet<Management> Managements { get; set; }

        //public DbSet<Player> Players { get; set; }
        
        public DbSet<PlayerStat> PlayerStats { get; set; }
        public DbSet<Fixture> Fixtures { get; set; }

        //public DbSet<FixtureResult> FixtureResults { get; set; }

        public DbSet<Person> Persons { get; set; }

        public ClubContext(DbContextOptions<ClubContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Club>().HasData(new Club { ClubID = 1, Address = "Bushy Park", Name = "Ratharnham Rovers", Email = "X00152190@mytudublin.ie", Number = "0872878566" });

            modelBuilder.Entity<Team>().HasData(new Team { ClubID = 1, Name = "First Team", TeamID = 1});
            modelBuilder.Entity<Team>().HasData(new Team { ClubID = 1, Name = "Under 21s", TeamID = 2 });
            modelBuilder.Entity<Team>().HasData(new Team { ClubID = 1, Name = "Under 19s", TeamID = 3 });
            modelBuilder.Entity<Team>().HasData(new Team { ClubID = 1, Name = "Under 17s", TeamID = 4 });
            modelBuilder.Entity<Team>().HasData(new Team { ClubID = 1, Name = "Under 15s", TeamID = 5 });
            modelBuilder.Entity<Team>().HasData(new Team { ClubID = 1, Name = "Under 13s", TeamID = 6 });
            modelBuilder.Entity<Team>().HasData(new Team { ClubID = 1, Name = "Under 11s", TeamID = 7 });

            modelBuilder.Entity<Person>().HasData(new Person { PersonID = 1, FirstName = "Ronan", Surname = "Breen", PersonType = PersonType.Player, PlayerPosition = PlayerPosition.Defender, TeamName = "First Team" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonID = 2, FirstName = "Ronan", Surname = "Grey", PersonType = PersonType.Player, PlayerPosition = PlayerPosition.Goalkeeper, TeamName = "First Team" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonID = 3, FirstName = "Richard", Surname = "Breen", PersonType = PersonType.Player, PlayerPosition = PlayerPosition.Midfielder, TeamName = "First Team" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonID = 4, FirstName = "Andrew", Surname = "Breen", PersonType = PersonType.Player, PlayerPosition = PlayerPosition.Forward, TeamName = "First Team" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonID = 5, FirstName = "Murray", Surname = "Breen", PersonType = PersonType.Player, PlayerPosition = PlayerPosition.Defender, TeamName = "First Team" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonID = 6, FirstName = "Patricia", Surname = "Breen", PersonType = PersonType.Player, PlayerPosition = PlayerPosition.Goalkeeper, TeamName = "First Team" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonID = 7, FirstName = "Elmond", Surname = "Breen", PersonType = PersonType.Manager, MgmtRole=MgmtRole.Manager, TeamName = "First Team" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonID = 8, FirstName = "Tim", Surname = "Breen", PersonType = PersonType.Player, PlayerPosition = PlayerPosition.Goalkeeper, TeamName = "Under 21s" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonID = 9, FirstName = "Tom", Surname = "Grey", PersonType = PersonType.Player, PlayerPosition = PlayerPosition.Defender, TeamName = "Under 21s" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonID = 10, FirstName = "Trevor", Surname = "Breen", PersonType = PersonType.Player, PlayerPosition = PlayerPosition.Midfielder, TeamName = "Under 21s" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonID = 11, FirstName = "Tilly", Surname = "Breen", PersonType = PersonType.Player, PlayerPosition = PlayerPosition.Forward, TeamName = "Under 19s" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonID = 12, FirstName = "Tyrance", Surname = "Breen", PersonType = PersonType.Player, PlayerPosition = PlayerPosition.Goalkeeper, TeamName = "Under 19s" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonID = 13, FirstName = "Tombo", Surname = "Breen", PersonType = PersonType.Player, PlayerPosition = PlayerPosition.Defender, TeamName = "Under 19s" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonID = 14, FirstName = "Timo", Surname = "Breen", PersonType = PersonType.Manager, PlayerPosition = PlayerPosition.Forward, TeamName = "Under 19s" });

            modelBuilder.Entity<PlayerStat>().HasData(new PlayerStat { PlayerStatID = 1, GamesPlayed = 5, Goals = 3, Assists = 5, MotmAward = 3, RedCards = 2, PersonID = 1 });
            modelBuilder.Entity<PlayerStat>().HasData(new PlayerStat { PlayerStatID = 2, GamesPlayed = 3, Goals = 1, Assists = 1, MotmAward = 1, RedCards = 0, PersonID = 2 });
            modelBuilder.Entity<PlayerStat>().HasData(new PlayerStat { PlayerStatID = 3, GamesPlayed = 2, Goals = 2, Assists = 2, MotmAward = 2, RedCards = 2, PersonID = 3 });
            modelBuilder.Entity<PlayerStat>().HasData(new PlayerStat { PlayerStatID = 4, GamesPlayed = 3, Goals = 3, Assists = 5, MotmAward = 3, RedCards = 2, PersonID = 4 });
            modelBuilder.Entity<PlayerStat>().HasData(new PlayerStat { PlayerStatID = 5, GamesPlayed = 5, Goals = 3, Assists = 5, MotmAward = 3, RedCards = 2, PersonID = 5 });
            modelBuilder.Entity<PlayerStat>().HasData(new PlayerStat { PlayerStatID = 6, GamesPlayed = 5, Goals = 3, Assists = 5, MotmAward = 3, RedCards = 2, PersonID = 6 });
            modelBuilder.Entity<PlayerStat>().HasData(new PlayerStat { PlayerStatID = 7, GamesPlayed = 5, Goals = 3, Assists = 5, MotmAward = 3, RedCards = 2, PersonID = 7 });
            modelBuilder.Entity<PlayerStat>().HasData(new PlayerStat { PlayerStatID = 8, GamesPlayed = 5, Goals = 3, Assists = 5, MotmAward = 3, RedCards = 2, PersonID = 8 });
            modelBuilder.Entity<PlayerStat>().HasData(new PlayerStat { PlayerStatID = 9, GamesPlayed = 5, Goals = 3, Assists = 5, MotmAward = 3, RedCards = 2, PersonID = 9 });
            modelBuilder.Entity<PlayerStat>().HasData(new PlayerStat { PlayerStatID = 10, GamesPlayed = 5, Goals = 3, Assists = 5, MotmAward = 3, RedCards = 2, PersonID = 10 });
            modelBuilder.Entity<PlayerStat>().HasData(new PlayerStat { PlayerStatID = 11, GamesPlayed = 5, Goals = 3, Assists = 5, MotmAward = 3, RedCards = 2, PersonID = 11 });
            modelBuilder.Entity<PlayerStat>().HasData(new PlayerStat { PlayerStatID = 12, GamesPlayed = 5, Goals = 3, Assists = 5, MotmAward = 3, RedCards = 2, PersonID = 12 });
            modelBuilder.Entity<PlayerStat>().HasData(new PlayerStat { PlayerStatID = 13, GamesPlayed = 5, Goals = 3, Assists = 5, MotmAward = 3, RedCards = 2, PersonID = 13 });
            modelBuilder.Entity<PlayerStat>().HasData(new PlayerStat { PlayerStatID = 14, GamesPlayed = 5, Goals = 3, Assists = 5, MotmAward = 3, RedCards = 2, PersonID = 14 });


        }
    }
}