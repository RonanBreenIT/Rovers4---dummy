using Microsoft.EntityFrameworkCore;
using Rovers4.Data;
using Rovers4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Rovers4.Tests
{
    public class FixtureTests
    {
        [Fact]
        public void Index_Fixture()
        {
            //Arrange
            IFixtureRepository sut = GetInMemoryFixtureRepository();
            Fixture fixture = new Fixture()
            {
                TeamID = 1,
                FixtureID = 1,
                FixtureDate = DateTime.Parse("2020-01-01"),
                FixtureType = FixtureType.Cup,
                Opponent = "Leeds",
                ResultDescription = ResultDescription.Win,
                OurScore = 3,
                OpponentScore = 1,
                HomeOrAway = HomeOrAway.Home,
                Location = "Bushy Park",
                MeetLocation = "Bushy Park Entrance",
                MeetTime = DateTime.Parse("2020-01-01"),
                MatchReport = "This was a good game.... "
            };

            //Act
            Fixture savedFixture = sut.CreateFixture(fixture);

            //Assert
            Assert.Single(sut.AllFixtures);
            Assert.Equal(1, savedFixture.TeamID);
            Assert.Equal(1, savedFixture.FixtureID);
            Assert.Equal(DateTime.Parse("2020-01-01"), savedFixture.FixtureDate);
            Assert.Equal(FixtureType.Cup, savedFixture.FixtureType);
            Assert.Equal("Leeds", savedFixture.Opponent);
            Assert.Equal(ResultDescription.Win, savedFixture.ResultDescription);
            Assert.Equal(3, savedFixture.OurScore);
            Assert.Equal(1, savedFixture.OpponentScore);
            Assert.Equal(HomeOrAway.Home, savedFixture.HomeOrAway);
            Assert.Equal("Bushy Park", savedFixture.Location);
            Assert.Equal("Bushy Park Entrance", savedFixture.MeetLocation);
            Assert.Equal(DateTime.Parse("2020-01-01"), savedFixture.MeetTime);
            Assert.Equal("This was a good game.... ", savedFixture.MatchReport);
        }


        [Fact]
        public void Index_FixturesForAGivenMonth()
        {
            //Arrange
            IFixtureRepository sut = GetInMemoryFixtureRepository();
            Fixture fixture = new Fixture()
            {
                TeamID = 1,
                FixtureID = 1,
                FixtureDate = DateTime.Parse("2020-01-01"),
                FixtureType = FixtureType.Cup,
                Opponent = "Leeds",
                ResultDescription = ResultDescription.Win,
                OurScore = 3,
                OpponentScore = 1,
                HomeOrAway = HomeOrAway.Home,
                Location = "Bushy Park",
                MeetLocation = "Bushy Park Entrance",
                MeetTime = DateTime.Parse("2020-01-01"),
                MatchReport = "This was a good game.... "
            };
            Fixture fixture2 = new Fixture()
            {
                TeamID = 1,
                FixtureID = 2,
                FixtureDate = DateTime.Parse("2020-02-02"),
                FixtureType = FixtureType.Cup,
                Opponent = "Team2",
                ResultDescription = ResultDescription.Win,
                OurScore = 3,
                OpponentScore = 1,
                HomeOrAway = HomeOrAway.Home,
                Location = "Bushy Park",
                MeetLocation = "Bushy Park Entrance",
                MeetTime = DateTime.Parse("2020-01-01"),
                MatchReport = "This was a good game.... "
            };
            Fixture fixture3 = new Fixture()
            {
                TeamID = 1,
                FixtureID = 3,
                FixtureDate = DateTime.Parse("2020-01-01"),
                FixtureType = FixtureType.Cup,
                Opponent = "Team3",
                ResultDescription = ResultDescription.Win,
                OurScore = 3,
                OpponentScore = 1,
                HomeOrAway = HomeOrAway.Home,
                Location = "Bushy Park",
                MeetLocation = "Bushy Park Entrance",
                MeetTime = DateTime.Parse("2020-01-01"),
                MatchReport = "This was a good game.... "
            };
            Fixture fixture4 = new Fixture()
            {
                TeamID = 1,
                FixtureID = 4,
                FixtureDate = DateTime.Parse("2020-01-01"),
                FixtureType = FixtureType.Cup,
                Opponent = "Team4",
                ResultDescription = ResultDescription.Win,
                OurScore = 3,
                OpponentScore = 1,
                HomeOrAway = HomeOrAway.Home,
                Location = "Bushy Park",
                MeetLocation = "Bushy Park Entrance",
                MeetTime = DateTime.Parse("2020-01-01"),
                MatchReport = "This was a good game.... "
            };

            //Act
            Fixture savedFixture = sut.CreateFixture(fixture);
            Fixture savedFixture2 = sut.CreateFixture(fixture2);
            Fixture savedFixture3 = sut.CreateFixture(fixture3);
            Fixture savedFixture4 = sut.CreateFixture(fixture4);

            //Assert
            Assert.Equal(3, sut.JanuaryFixtures.Count());
            Assert.Equal("Leeds", sut.JanuaryFixtures.ToList()[0].Opponent);
            Assert.Equal("Team3", sut.JanuaryFixtures.ToList()[1].Opponent);
            Assert.Equal("Team4", sut.JanuaryFixtures.ToList()[2].Opponent);
        }

        [Fact]
        public void Index_TestTeamStats()
        {
            //Arrange
            IFixtureRepository sut = GetInMemoryFixtureRepository();
            Fixture fixture = new Fixture()
            {
                TeamID = 1,
                FixtureID = 1,
                FixtureDate = DateTime.Parse("2020-01-01"),
                FixtureType = FixtureType.Cup,
                Opponent = "Leeds",
                ResultDescription = ResultDescription.Win,
                OurScore = 3,
                OpponentScore = 1,
                HomeOrAway = HomeOrAway.Home,
                Location = "Bushy Park",
                MeetLocation = "Bushy Park Entrance",
                MeetTime = DateTime.Parse("2020-01-01"),
                MatchReport = "This was a good game.... "
            };
            Fixture fixture2 = new Fixture()
            {
                TeamID = 1,
                FixtureID = 2,
                FixtureDate = DateTime.Parse("2020-02-02"),
                FixtureType = FixtureType.Cup,
                Opponent = "Team2",
                ResultDescription = ResultDescription.Win,
                OurScore = 3,
                OpponentScore = 1,
                HomeOrAway = HomeOrAway.Home,
                Location = "Bushy Park",
                MeetLocation = "Bushy Park Entrance",
                MeetTime = DateTime.Parse("2020-01-01"),
                MatchReport = "This was a good game.... "
            };
            Fixture fixture3 = new Fixture()
            {
                TeamID = 1,
                FixtureID = 3,
                FixtureDate = DateTime.Parse("2020-01-01"),
                FixtureType = FixtureType.Cup,
                Opponent = "Team3",
                ResultDescription = ResultDescription.Win,
                OurScore = 3,
                OpponentScore = 1,
                HomeOrAway = HomeOrAway.Home,
                Location = "Bushy Park",
                MeetLocation = "Bushy Park Entrance",
                MeetTime = DateTime.Parse("2020-01-01"),
                MatchReport = "This was a good game.... "
            };
            Fixture fixture4 = new Fixture()
            {
                TeamID = 1,
                FixtureID = 4,
                FixtureDate = DateTime.Parse("2020-01-01"),
                FixtureType = FixtureType.Cup,
                Opponent = "Team4",
                ResultDescription = ResultDescription.Loss,
                OurScore = 1,
                OpponentScore = 2,
                HomeOrAway = HomeOrAway.Home,
                Location = "Bushy Park",
                MeetLocation = "Bushy Park Entrance",
                MeetTime = DateTime.Parse("2020-01-01"),
                MatchReport = "This was a good game.... "
            };

            //Act
            Fixture savedFixture = sut.CreateFixture(fixture);
            Fixture savedFixture2 = sut.CreateFixture(fixture2);
            Fixture savedFixture3 = sut.CreateFixture(fixture3);
            Fixture savedFixture4 = sut.CreateFixture(fixture4);

            //Assert
            Assert.Equal(3, sut.JanuaryFixtures.Count());
            Assert.Equal(3, sut.TotalWins(1));
            Assert.Equal(0, sut.TotalDraws(1));
            Assert.Equal(1, sut.TotalLosses(1));
            Assert.Equal(10, sut.GoalsFor(1));
            Assert.Equal(5, sut.GoalsAgainst(1));
        }

        [Fact]
        public void Index_UpdateOpponent()
        {
            //Arrange
            IFixtureRepository sut = GetInMemoryFixtureRepository();
            Fixture fixture = new Fixture()
            {
                TeamID = 1,
                FixtureID = 1,
                FixtureDate = DateTime.Parse("2020-01-01"),
                FixtureType = FixtureType.Cup,
                Opponent = "Leeds",
                ResultDescription = ResultDescription.Win,
                OurScore = 3,
                OpponentScore = 1,
                HomeOrAway = HomeOrAway.Home,
                Location = "Bushy Park",
                MeetLocation = "Bushy Park Entrance",
                MeetTime = DateTime.Parse("2020-01-01"),
                MatchReport = "This was a good game.... "
            };
            Fixture fixture2 = new Fixture()
            {
                TeamID = 1,
                FixtureID = 1,
                FixtureDate = DateTime.Parse("2020-02-02"),
                FixtureType = FixtureType.Cup,
                Opponent = "Team2",
                ResultDescription = ResultDescription.Win,
                OurScore = 3,
                OpponentScore = 1,
                HomeOrAway = HomeOrAway.Home,
                Location = "Bushy Park",
                MeetLocation = "Bushy Park Entrance",
                MeetTime = DateTime.Parse("2020-01-01"),
                MatchReport = "This was a good game.... "
            };
           
            //Act
            Fixture savedFixture = sut.CreateFixture(fixture);
            Fixture savedFixture2 = sut.UpdateFixture(fixture2);

            //Assert
            Assert.Single(sut.AllFixtures);
            Assert.Equal("Team2", sut.AllFixtures.ToList()[0].Opponent);
        }

        [Fact]
        public void Index_DeleteFixture()
        {
            //Arrange
            IFixtureRepository sut = GetInMemoryFixtureRepository();
            Fixture fixture = new Fixture()
            {
                TeamID = 1,
                FixtureID = 1,
                FixtureDate = DateTime.Parse("2020-01-01"),
                FixtureType = FixtureType.Cup,
                Opponent = "Leeds",
                ResultDescription = ResultDescription.Win,
                OurScore = 3,
                OpponentScore = 1,
                HomeOrAway = HomeOrAway.Home,
                Location = "Bushy Park",
                MeetLocation = "Bushy Park Entrance",
                MeetTime = DateTime.Parse("2020-01-01"),
                MatchReport = "This was a good game.... "
            };

            //Act
            Fixture savedFixture = sut.CreateFixture(fixture);
            Fixture savedFixture2 = sut.DeleteFixture(fixture);

            //Assert
            Assert.Empty(sut.AllFixtures);
        }

        private IFixtureRepository GetInMemoryFixtureRepository()
        {
            var builder = new DbContextOptionsBuilder<ClubContext>().UseInMemoryDatabase(databaseName: "FixtureListDb").Options;
            ClubContext clubDataContext = new ClubContext(builder);
            clubDataContext.Database.EnsureDeleted();
            clubDataContext.Database.EnsureCreated();
            return new FixtureRepository(clubDataContext);
        }
    }
}
