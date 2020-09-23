using Rovers4.Models;
using System;
using Xunit;

namespace Rovers4.Tests
{
    public class SampleTests
    {
        [Fact]
        public void CanUpdateClubName()
        {
            // Arrange
            var club = new Club { Name = "Rovers1" };
            // Act
            club.Name = "Rovers2";
            //Assert
            Assert.Equal("Rovers2", club.Name);
        }
    }
}
