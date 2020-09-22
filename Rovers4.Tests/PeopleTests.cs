using Microsoft.EntityFrameworkCore;
using Rovers4.Data;
using Rovers4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Rovers4.Tests.Model
{
    public class PeopleTests
    {
        [Fact]
        public void Index_PlayerWithPlayerStats()
        {
            //Arrange
            IPersonRepository sut = GetInMemoryPersonRepository();
            Person person = new Person()
            {
                TeamID = 1,
                FirstName = "Test",
                Surname = "Player",
                Image = "image1.png",
                ThumbnailImage = "image2.png",
                Mobile = "111 1111111",
                Email = "111@sss.com",
                PersonType = PersonType.Player,
                PlayerPosition = PlayerPosition.Goalkeeper,
                DOB = DateTime.Parse("2000-03-02"),
                PlayerStat = new PlayerStat()
                {
                    GamesPlayed = 10,
                    CleanSheet = 6
                }
            };

            //Act
            Person savedPerson = sut.CreatePerson(person);

            //Assert
            Assert.Single(sut.GetPeople());
            Assert.Equal("Test Player", savedPerson.FullName);
            Assert.Equal("image1.png", savedPerson.Image);
            Assert.Equal("image2.png", savedPerson.ThumbnailImage);
            Assert.Equal("111 1111111", savedPerson.Mobile);
            Assert.Equal("111@sss.com", savedPerson.Email);
            Assert.Equal(PersonType.Player, savedPerson.PersonType);
            Assert.Equal(PlayerPosition.Goalkeeper, savedPerson.PlayerPosition);
            Assert.Equal(DateTime.Parse("2000-03-02"), savedPerson.DOB);
            Assert.Equal(10, savedPerson.PlayerStat.GamesPlayed);
            Assert.Equal(6, savedPerson.PlayerStat.CleanSheet);

        }

        [Fact]
        public void GetPersonByID()
        {
            //Arrange
            IPersonRepository sut = GetInMemoryPersonRepository();
            Person person = new Person()
            {
                PersonID = 1,
                TeamID = 1,
                FirstName = "Test",
                Surname = "Player",
                Image = "image1.png",
                ThumbnailImage = "image2.png",
                Mobile = "111 1111111",
                Email = "111@sss.com",
                PersonType = PersonType.Player,
                PlayerPosition = PlayerPosition.Goalkeeper,
                DOB = DateTime.Parse("2000-03-02"),
                PlayerStat = new PlayerStat()
                {
                    GamesPlayed = 10,
                    CleanSheet = 6
                }
            };

          
            Person person2 = new Person()
            {
                PersonID = 2,
                TeamID = 1,
                FirstName = "Test",
                Surname = "PlayerTwo",
                Image = "image11.png",
                ThumbnailImage = "image22.png",
                Mobile = "111 1111111",
                Email = "111@sss.com",
                PersonType = PersonType.Player,
                PlayerPosition = PlayerPosition.Goalkeeper,
                DOB = DateTime.Parse("2000-03-02"),
                PlayerStat = new PlayerStat()
                {
                    GamesPlayed = 10,
                    CleanSheet = 6
                }
            };

            //Act
            Person savedPerson = sut.CreatePerson(person);
            Person savedPerson2 = sut.CreatePerson(person2);

            //Assert
            var foundPersonByID = sut.GetPersonById(2);
            Assert.Equal("Test PlayerTwo", foundPersonByID.FullName);
        }

        [Fact]
        public void Index_Update_Name()
        {
            //Arrange
            IPersonRepository sut = GetInMemoryPersonRepository();
          
            Person person = new Person()
            {
                TeamID = 1,
                FirstName = "Test",
                Surname = "Player",
                Image = "image1.png",
                ThumbnailImage = "image2.png",
                Mobile = "111 1111111",
                Email = "111@sss.com",
                PersonType = PersonType.Player,
                PlayerPosition = PlayerPosition.Goalkeeper,
                DOB = DateTime.Parse("2000-03-02"),
                PlayerStat = new PlayerStat()
                {
                    GamesPlayed = 10,
                    CleanSheet = 6
                }
            };


            Person person2 = new Person()
            {
                TeamID = 1,
                FirstName = "Test",
                Surname = "PlayerTwo",
                Image = "image11.png",
                ThumbnailImage = "image22.png",
                Mobile = "111 1111111",
                Email = "111@sss.com",
                PersonType = PersonType.Player,
                PlayerPosition = PlayerPosition.Forward,
                DOB = DateTime.Parse("2000-03-02"),
                PlayerStat = new PlayerStat()
                {
                    GamesPlayed = 10,
                    Goals = 7
                }
            };

            //Act
            Person savedPerson = sut.CreatePerson(person);
            Person UpdatedPerson2 = sut.CreatePerson(person2);

            //Assert
            Assert.Equal(2, sut.GetPeople().Count);
            Assert.Equal("Test PlayerTwo", UpdatedPerson2.FullName);
        }

        [Fact]
        public void Index_DeletePerson()
        {
            //Arrange
            IPersonRepository sut = GetInMemoryPersonRepository();

            Person person = new Person()
            {
                TeamID = 1,
                FirstName = "Test",
                Surname = "Player",
                Image = "image1.png",
                ThumbnailImage = "image2.png",
                Mobile = "111 1111111",
                Email = "111@sss.com",
                PersonType = PersonType.Player,
                PlayerPosition = PlayerPosition.Goalkeeper,
                DOB = DateTime.Parse("2000-03-02"),
                PlayerStat = new PlayerStat()
                {
                    GamesPlayed = 10,
                    CleanSheet = 6
                }
            };

            //Act
            Person savedPerson = sut.CreatePerson(person);
            Person deletedPerson = sut.DeletePerson(person);

            //Assert
            Assert.Empty(sut.GetPeople());
        }


        [Fact]
        public void Missing_Required_Name()
        {
            //Arrange
            IPersonRepository sut = GetInMemoryPersonRepository();
            CheckPropertyValidation cpv = new CheckPropertyValidation();

            Person person = new Person()
            {
                TeamID = 1,
                //FirstName = "Test",
                //Surname = "Player",
                Image = "image1.png",
                ThumbnailImage = "image2.png",
                Mobile = "111 1111111",
                Email = "111@sss.com",
                PersonType = PersonType.Player,
                PlayerPosition = PlayerPosition.Goalkeeper,
                DOB = DateTime.Parse("2000-03-02"),
                PlayerStat = new PlayerStat()
                {
                    GamesPlayed = 10,
                    CleanSheet = 6
                }
            };

            //Act
            Person savedPerson = sut.CreatePerson(person);

            //Assert
            var errorcount = cpv.myValidation(person).Count();
            Assert.Equal(2, errorcount); // 2 as for FirstName and Surname
        }



        private IPersonRepository GetInMemoryPersonRepository()
        {
            var builder = new DbContextOptionsBuilder<ClubContext>().UseInMemoryDatabase(databaseName: "PersonListDb").Options;
            ClubContext clubDataContext = new ClubContext(builder);
            clubDataContext.Database.EnsureDeleted();
            clubDataContext.Database.EnsureCreated();
            return new PersonRepository(clubDataContext);
        }
    }
}

