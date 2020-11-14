using Microsoft.EntityFrameworkCore;
using Rovers4.Data;
using Rovers4.Models;
using Rovers4.Tests.Model;
using System.Linq;
using Xunit;

namespace Rovers4.Tests
{
    public class ClubTests
    {
        [Fact]
        public void Index_AllItems()
        {
            //Arrange
            IClubRepository sut = GetInMemoryClubRepository();
            Club club = new Club()
            {
                ClubID = 1,
                Name = "Rathfarnham Mock",
                Number = "123 4567899",
                Email = "111@hotmail.com",
                Address = "1 Main Street",
                ClubImage1 = "image1.png",
                ClubImage2 = "image2.png",
                ClubImage3 = "image3.png",
            };

            //Act
            Club savedClub = sut.CreateClub(club);

            //Assert
            Assert.Single(sut.GetClubs());
            Assert.Equal("Rathfarnham Mock", savedClub.Name);
            Assert.Equal("123 4567899", savedClub.Number);
            Assert.Equal("111@hotmail.com", savedClub.Email);
            Assert.Equal("1 Main Street", savedClub.Address);
            Assert.Equal("image1.png", savedClub.ClubImage1);
            Assert.Equal("image2.png", savedClub.ClubImage2);
            Assert.Equal("image3.png", savedClub.ClubImage3);
        }

        [Fact]
        public void Index_Add_WithNoEmail()
        {
            //Arrange
            IClubRepository sut = GetInMemoryClubRepository();
            Club club = new Club()
            {
                ClubID = 1,
                Name = "Rathfarnham Mock",
                Number = "123 4567899",
            };

            //Act
            Club savedClub = sut.CreateClub(club);

            //Assert
            Assert.Single(sut.GetClubs());
            Assert.Equal("Rathfarnham Mock", savedClub.Name);
            Assert.Equal("123 4567899", savedClub.Number);
            Assert.Null(savedClub.Email);
        }

        [Fact]
        public void Index_Update_Name()
        {
            //Arrange
            IClubRepository sut = GetInMemoryClubRepository();
            Club club = new Club()
            {
                ClubID = 1,
                Name = "Rathfarnham Mock",
                Number = "123 4567899",
                Email = "111@hotmail.com"
            };
            Club newClub = new Club()
            {
                ClubID = 1,
                Name = "Updated Club",
            };

            //Act
            sut.CreateClub(club);
            Club updatedClub = sut.UpdateClub(newClub);

            //Assert
            Assert.Single(sut.GetClubs());
            Assert.Equal("Updated Club", updatedClub.Name);
        }

        [Fact]
        public void Index_DeleteClub()
        {
            //Arrange
            IClubRepository sut = GetInMemoryClubRepository();
            Club club = new Club()
            {
                ClubID = 1,
                Name = "Rathfarnham Mock",
                Number = "123 4567899",
                Email = "111@hotmail.com"
            };

            //Act
            sut.CreateClub(club);
            sut.DeleteClub(club);

            //Assert
            Assert.Empty(sut.GetClubs());
        }

        [Fact]
        public void Multiple_Clubs()
        {
            //Arrange
            IClubRepository sut = GetInMemoryClubRepository();
            Club club = new Club()
            {
                ClubID = 1,
                Name = "Rathfarnham Mock",
                Number = "123 4567899",
                Email = "111@hotmail.com"
            };
            Club club2 = new Club()
            {
                ClubID = 2,
                Name = "Mock",
                Number = "1234567899",
                Email = "222@hotmail.com"
            };

            //Act
            sut.CreateClub(club);
            sut.CreateClub(club2);

            //Assert
            Assert.Equal(2, sut.GetClubs().Count);
        }

        [Fact]
        public void Missing_Required_Name()
        {
            //Arrange
            IClubRepository sut = GetInMemoryClubRepository();
            CheckPropertyValidation cpv = new CheckPropertyValidation();

            Club club = new Club()
            {
                ClubID = 1,
                //Name = "Rathfarnham Mock",
                Number = "123 4567899",
                Email = "111@hotmail.com",
                Address = "1 Main Street",
                ClubImage1 = "image1.png",
                ClubImage2 = "image2.png",
                ClubImage3 = "image3.png",
            };

            //Act
            sut.CreateClub(club);

            //Assert
            var errorcount = cpv.myValidation(club).Count();
            Assert.Equal(1, errorcount);
        }

        [Fact]
        public void Missing_Four_Required_Properties()
        {
            //Arrange
            IClubRepository sut = GetInMemoryClubRepository();
            CheckPropertyValidation cpv = new CheckPropertyValidation();

            Club club = new Club()
            {
                ClubID = 1,
                //Name = "Rathfarnham Mock",
                //Number = "123 4567899",
                //Email = "111@hotmail.com",
                //Address = "1 Main Street",
                ClubImage1 = "image1.png",
                ClubImage2 = "image2.png",
                ClubImage3 = "image3.png",
            };

            //Act
            sut.CreateClub(club);

            //Assert
            var errorcount = cpv.myValidation(club).Count();
            Assert.Equal(4, errorcount);
        }

        private IClubRepository GetInMemoryClubRepository()
        {
            var builder = new DbContextOptionsBuilder<ClubContext>().UseInMemoryDatabase(databaseName: "ClubListDb").Options;
            ClubContext clubDataContext = new ClubContext(builder);
            clubDataContext.Database.EnsureDeleted();
            clubDataContext.Database.EnsureCreated();
            return new ClubRepository(clubDataContext);
        }
    }
}