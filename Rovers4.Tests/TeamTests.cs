using Microsoft.EntityFrameworkCore;
using Rovers4.Data;
using Rovers4.Models;
using Rovers4.Tests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Rovers4.Tests
{
    public class TeamTests
    {
        [Fact]
        public void Index_TeamWithMultiplePlayers()
        {
            //Arrange
            ITeamRepository sut = GetInMemoryTeamRepository();
            Team team = new Team()
            {
                TeamID = 1,
                Name = "first Team",
                TeamBio = "this is the first team",
                TeamImage = "image1.png",
                Staff = new List<Person>()
                {
                    new Person()
                    {
                        PersonID = 1, FirstName = "Player",
                        Surname = "One",
                        PersonType = PersonType.Player,
                        PlayerPosition = PlayerPosition.Defender,
                        TeamID = 1,
                        ThumbnailImage = "image1.jpg",
                        Image = "image2.jp",
                        DOB = DateTime.Parse("2000-01-02"),
                        Email = "X@X.com",
                        Mobile = "111 1111111",
                        PersonBio = "test player..."
                    },
                    new Person()
                    {
                        PersonID = 2, FirstName = "Player",
                        Surname = "Two",
                        PersonType = PersonType.Player,
                        PlayerPosition = PlayerPosition.Midfielder,
                        TeamID = 1,
                        ThumbnailImage = "image1.jpg",
                        Image = "image2.jp",
                        DOB = DateTime.Parse("2000-01-02"),
                        Email = "X@X.com",
                        Mobile = "111 1111111",
                        PersonBio = "test player..."
                    },
                    new Person()
                    {
                        PersonID = 3, FirstName = "Manager",
                        Surname = "One",
                        PersonType = PersonType.Player,
                        PlayerPosition = PlayerPosition.Defender,
                        TeamID = 1,
                        ThumbnailImage = "image1.jpg",
                        Image = "image2.jp",
                        DOB = DateTime.Parse("2080-01-02"),
                        Email = "X@X.com",
                        Mobile = "111 1111111",
                        PersonBio = "test player..."
                    }
                }
            };

            //Act
            Team savedTeam = sut.CreateTeam(team);

            //Assert
            Assert.Single(sut.GetTeams());
            Assert.Equal("first Team", savedTeam.Name);
            Assert.Equal("this is the first team", savedTeam.TeamBio);
            Assert.Equal("image1.png", savedTeam.TeamImage);
            Assert.Equal(3, savedTeam.Staff.Count);
            Assert.Equal("Player One", savedTeam.Staff.ToList()[0].FullName);
            Assert.Equal("Player Two", savedTeam.Staff.ToList()[1].FullName);
            Assert.Equal("Manager One", savedTeam.Staff.ToList()[2].FullName);
        }

        [Fact]
        public void GetTeamByID()
        {
            //Arrange
            ITeamRepository sut = GetInMemoryTeamRepository();
            Team team = new Team()
            {
                TeamID = 1,
                Name = "first Team",
                TeamBio = "this is the first team",
                TeamImage = "image1.png",
            };
            Team team2 = new Team()
            {
                TeamID = 2,
                Name = "under 17s",
                TeamBio = "this is the 17s",
                TeamImage = "image1.png",
            };

            //Act
            sut.CreateTeam(team);
            sut.CreateTeam(team2);

            //Assert
            var foundTeamByID = sut.GetTeamById(2);
            Assert.Equal("under 17s", foundTeamByID.Name);
        }

        [Fact]
        public void Index_MultipleTeamsWithMultiplePlayersAndFixtures()
        {
            //Arrange
            ITeamRepository sut = GetInMemoryTeamRepository();
            Team team = new Team()
            {
                TeamID = 1,
                Name = "first Team",
                TeamBio = "this is the first team",
                TeamImage = "image1.png",
                Staff = new List<Person>()
                {
                    new Person()
                    {
                        PersonID = 1, FirstName = "Player",
                        Surname = "One",
                        PersonType = PersonType.Player,
                        PlayerPosition = PlayerPosition.Defender,
                        TeamID = 1,
                        ThumbnailImage = "image1.jpg",
                        Image = "image2.jp",
                        DOB = DateTime.Parse("2000-01-02"),
                        Email = "X@X.com",
                        Mobile = "111 1111111",
                        PersonBio = "test player..."
                    },
                    new Person()
                    {
                        PersonID = 2, FirstName = "Player",
                        Surname = "Two",
                        PersonType = PersonType.Player,
                        PlayerPosition = PlayerPosition.Midfielder,
                        TeamID = 1,
                        ThumbnailImage = "image1.jpg",
                        Image = "image2.jp",
                        DOB = DateTime.Parse("2000-01-02"),
                        Email = "X@X.com",
                        Mobile = "111 1111111",
                        PersonBio = "test player..."
                    },
                    new Person()
                    {
                        PersonID = 3, FirstName = "Manager",
                        Surname = "One",
                        PersonType = PersonType.Player,
                        PlayerPosition = PlayerPosition.Defender,
                        TeamID = 1,
                        ThumbnailImage = "image1.jpg",
                        Image = "image2.jp",
                        DOB = DateTime.Parse("2080-01-02"),
                        Email = "X@X.com",
                        Mobile = "111 1111111",
                        PersonBio = "test player..."
                    }
                },
                fixtures = new List<Fixture>()
                {
                    new Fixture()
                    {
                        FixtureID = 1,
                        FixtureDate = DateTime.Parse("2020-01-01"),
                        FixtureType = FixtureType.Cup
                    },
                    new Fixture()
                    {
                        FixtureID = 2,
                        FixtureDate = DateTime.Parse("2020-01-01"),
                        FixtureType = FixtureType.Friendly
                    },
                    new Fixture()
                    {
                        FixtureID = 3,
                        FixtureDate = DateTime.Parse("2020-01-01"),
                        FixtureType = FixtureType.League
                    }
                }
            };

            Team team2 = new Team()
            {
                TeamID = 2,
                Name = "Under 21s",
                TeamBio = "this is the 21s",
                TeamImage = "image2.png",
                Staff = new List<Person>()
                {
                    new Person()
                    {
                        PersonID = 4, FirstName = "Player",
                        Surname = "One",
                        PersonType = PersonType.Player,
                        PlayerPosition = PlayerPosition.Defender,
                        TeamID = 1,
                        ThumbnailImage = "image1.jpg",
                        Image = "image2.jp",
                        DOB = DateTime.Parse("2000-01-02"),
                        Email = "X@X.com",
                        Mobile = "111 1111111",
                        PersonBio = "test player..."
                    },
                    new Person()
                    {
                        PersonID = 5, FirstName = "Player",
                        Surname = "Two",
                        PersonType = PersonType.Player,
                        PlayerPosition = PlayerPosition.Midfielder,
                        TeamID = 1,
                        ThumbnailImage = "image1.jpg",
                        Image = "image2.jp",
                        DOB = DateTime.Parse("2000-01-02"),
                        Email = "X@X.com",
                        Mobile = "111 1111111",
                        PersonBio = "test player..."
                    },
                    new Person()
                    {
                        PersonID = 6, FirstName = "Manager",
                        Surname = "One",
                        PersonType = PersonType.Player,
                        PlayerPosition = PlayerPosition.Defender,
                        TeamID = 1,
                        ThumbnailImage = "image1.jpg",
                        Image = "image2.jp",
                        DOB = DateTime.Parse("2080-01-02"),
                        Email = "X@X.com",
                        Mobile = "111 1111111",
                        PersonBio = "test player..."
                    }
                },
                fixtures = new List<Fixture>()
                {
                    new Fixture()
                    {
                        FixtureID = 4,
                        FixtureDate = DateTime.Parse("2020-01-01"),
                        FixtureType = FixtureType.Cup
                    },
                    new Fixture()
                    {
                        FixtureID = 5,
                        FixtureDate = DateTime.Parse("2020-01-01"),
                        FixtureType = FixtureType.Friendly
                    },
                    new Fixture()
                    {
                        FixtureID = 6,
                        FixtureDate = DateTime.Parse("2020-01-01"),
                        FixtureType = FixtureType.League
                    }
                }
            };

            //Act
            Team savedTeam = sut.CreateTeam(team);
            Team savedTeam2 = sut.CreateTeam(team2);

            //Assert
            Assert.Equal(2, sut.GetTeams().Count);
            
            Assert.Equal("first Team", savedTeam.Name);
            Assert.Equal("this is the first team", savedTeam.TeamBio);
            Assert.Equal("image1.png", savedTeam.TeamImage);
            Assert.Equal(3, savedTeam.Staff.Count);
            Assert.Equal("Player One", savedTeam.Staff.ToList()[0].FullName);
            Assert.Equal("Player Two", savedTeam.Staff.ToList()[1].FullName);
            Assert.Equal("Manager One", savedTeam.Staff.ToList()[2].FullName);
            Assert.Equal(1, savedTeam.fixtures.ToList()[0].FixtureID);
            Assert.Equal(2, savedTeam.fixtures.ToList()[1].FixtureID);
            Assert.Equal(3, savedTeam.fixtures.ToList()[2].FixtureID);

            Assert.Equal("Under 21s", savedTeam2.Name);
            Assert.Equal("this is the 21s", savedTeam2.TeamBio);
            Assert.Equal("image2.png", savedTeam2.TeamImage);
            Assert.Equal(3, savedTeam2.Staff.Count);
            Assert.Equal("Player One", savedTeam2.Staff.ToList()[0].FullName);
            Assert.Equal("Player Two", savedTeam2.Staff.ToList()[1].FullName);
            Assert.Equal("Manager One", savedTeam2.Staff.ToList()[2].FullName);
            Assert.Equal(4, savedTeam2.fixtures.ToList()[0].FixtureID);
            Assert.Equal(5, savedTeam2.fixtures.ToList()[1].FixtureID);
            Assert.Equal(6, savedTeam2.fixtures.ToList()[2].FixtureID);
        }

        [Fact]
        public void Index_Update_Name()
        {
            //Arrange
            ITeamRepository sut = GetInMemoryTeamRepository();
            Team team = new Team()
            {
                TeamID = 1,
                Name = "first Team",
                TeamBio = "this is the first team",
                TeamImage = "image1.png",
                Staff = new List<Person>()
                {
                    new Person()
                    {
                        PersonID = 1, FirstName = "Player",
                        Surname = "One",
                        PersonType = PersonType.Player,
                        PlayerPosition = PlayerPosition.Defender,
                        TeamID = 1,
                        ThumbnailImage = "image1.jpg",
                        Image = "image2.jp",
                        DOB = DateTime.Parse("2000-01-02"),
                        Email = "X@X.com",
                        Mobile = "111 1111111",
                        PersonBio = "test player..."
                    },
                    new Person()
                    {
                        PersonID = 2, FirstName = "Player",
                        Surname = "Two",
                        PersonType = PersonType.Player,
                        PlayerPosition = PlayerPosition.Midfielder,
                        TeamID = 1,
                        ThumbnailImage = "image1.jpg",
                        Image = "image2.jp",
                        DOB = DateTime.Parse("2000-01-02"),
                        Email = "X@X.com",
                        Mobile = "111 1111111",
                        PersonBio = "test player..."
                    },
                    new Person()
                    {
                        PersonID = 3, FirstName = "Manager",
                        Surname = "One",
                        PersonType = PersonType.Player,
                        PlayerPosition = PlayerPosition.Defender,
                        TeamID = 1,
                        ThumbnailImage = "image1.jpg",
                        Image = "image2.jp",
                        DOB = DateTime.Parse("2080-01-02"),
                        Email = "X@X.com",
                        Mobile = "111 1111111",
                        PersonBio = "test player..."
                    }


                }
            };

            Team team2 = new Team()
            {
                TeamID = 1,
                Name = "Under 21s",
                TeamBio = "this is the 21s",
                TeamImage = "image2.png",
                Staff = new List<Person>()
                {
                    new Person()
                    {
                        PersonID = 1, FirstName = "Player",
                        Surname = "One",
                        PersonType = PersonType.Player,
                        PlayerPosition = PlayerPosition.Defender,
                        TeamID = 1,
                        ThumbnailImage = "image1.jpg",
                        Image = "image2.jp",
                        DOB = DateTime.Parse("2000-01-02"),
                        Email = "X@X.com",
                        Mobile = "111 1111111",
                        PersonBio = "test player..."
                    },
                    new Person()
                    {
                        PersonID = 2, FirstName = "Player",
                        Surname = "Two",
                        PersonType = PersonType.Player,
                        PlayerPosition = PlayerPosition.Midfielder,
                        TeamID = 1,
                        ThumbnailImage = "image1.jpg",
                        Image = "image2.jp",
                        DOB = DateTime.Parse("2000-01-02"),
                        Email = "X@X.com",
                        Mobile = "111 1111111",
                        PersonBio = "test player..."
                    },
                    new Person()
                    {
                        PersonID = 3, FirstName = "Manager",
                        Surname = "One",
                        PersonType = PersonType.Player,
                        PlayerPosition = PlayerPosition.Defender,
                        TeamID = 1,
                        ThumbnailImage = "image1.jpg",
                        Image = "image2.jp",
                        DOB = DateTime.Parse("2080-01-02"),
                        Email = "X@X.com",
                        Mobile = "111 1111111",
                        PersonBio = "test player..."
                    }
                }
            };

            //Act
            sut.CreateTeam(team);
            Team updatedTeam = sut.UpdateTeam(team2);

            //Assert
            Assert.Single(sut.GetTeams());
            Assert.Equal("Under 21s", updatedTeam.Name);
        }

        [Fact]
        public void Index_DeleteClub()
        {
            //Arrange
            ITeamRepository sut = GetInMemoryTeamRepository();
            Team team = new Team()
            {
                TeamID = 1,
                Name = "first Team"
            };

            //Act
            sut.CreateTeam(team);
            sut.DeleteTeam(team);

            //Assert
            Assert.Empty(sut.GetTeams());
        }


        [Fact]
        public void Missing_Required_Name()
        {
            //Arrange
            ITeamRepository sut = GetInMemoryTeamRepository();
            CheckPropertyValidation cpv = new CheckPropertyValidation();

            Team team = new Team()
            {
                TeamID = 1,
                //Name = "first Team"
            };

            //Act
            sut.CreateTeam(team);

            //Assert
            var errorcount = cpv.myValidation(team).Count();
            Assert.Equal(1, errorcount);
        }

        

        private ITeamRepository GetInMemoryTeamRepository()
        {
            var builder = new DbContextOptionsBuilder<ClubContext>().UseInMemoryDatabase(databaseName: "TeamListDb").Options;
            ClubContext clubDataContext = new ClubContext(builder);
            clubDataContext.Database.EnsureDeleted();
            clubDataContext.Database.EnsureCreated();
            return new TeamRepository(clubDataContext);
        }
    }
}
