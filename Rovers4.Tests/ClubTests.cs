using Microsoft.AspNetCore.Mvc;
using Moq;
using Rovers4.Controllers;
using Rovers4.Models;
using Rovers4.Tests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Rovers4.Tests
{
    public class ClubTests
    {
        //[Fact]
        //public async void Clubs_Index()
        //{
        //    //arrange
            //var mockClubsRepository = RepositoryMocks.GetClubs();
           
            //var clubController = new ClubController(mockClubsRepository.Object);

            ////act
            //var result = await clubController.Index();
            //var result = await controller.GetOrders();//
            //var okResult = result as OkObjectResult;

            //assert
            //var viewResult = Assert.IsAssignableFrom<RedirectToActionResult>(result);
            //var club = Assert.IsAssignableFrom<IEnumerable<Club>>(viewResult);
            //Assert.Single(club);
            //var viewResult = Assert.IsType<ViewResult>(result);
            //var model = Assert.IsAssignableFrom < IEnumerable <Club>>(
            //    viewResult.ViewData.Model);
            //Assert.Equal(1, model.Count());

        //}



        [Fact]
        public void CreateClub()
        {
            // Arrange
            var club = GetDemoClub();
  
            //Assert
            Assert.Equal("Mock Name", club.Name);
            Assert.Equal("Mock Name", club.Name);
            Assert.Equal("Mock Name", club.Name);
        }
        
        [Fact]
        public void CanUpdateClubName()
        {
            // Arrange
            var club = GetDemoClub();
            // Act
            club.Name = "Rovers2";
            //Assert
            Assert.Equal("Rovers2", club.Name);
        }

        //[Fact]
        //public void DeleteClub()
        //{
        //    // Arrange
        //    var club = GetDemoClub();
        //    var clubController = new ClubController();
        //    // Act
        //    var result = clubController.Delete(club.ClubID);
  
        //    //Assert
        //    Assert.Equal("Rovers2", club.Name);
        //}


        Club GetDemoClub()
        {
            return new Club() { ClubID=1, Name = "Demo Club", Address = "Test 1", 
                ClubImage1 = "image1.png", ClubImage2 = "image2.png", ClubImage3 = "image3.png",
                Email = "111@sss.com", Number = "111 1111111"
            };
        }
    }
}