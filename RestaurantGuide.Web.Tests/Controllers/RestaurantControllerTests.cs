using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantGuide.Entities;
using RestaurantGuide.Web.Controllers;
using RestaurantGuide.Web.Tests.Mocks;

namespace RestaurantGuide.Web.Tests.Controllers
{
    [TestClass]
    public class RestaurantControllerTests
    {
        [TestMethod]
        public void Create_Saves_Restaurant_When_Valid()
        {
            // Arrange
            var mockRepository = new MockRestaurantRepository();
            var controller = new RestaurantController(mockRepository);

            // Act
            controller.Create(new Restaurant());

            // Assert
            Assert.AreEqual(1, mockRepository.GetAll().Count());
        }

        [TestMethod]
        public void Create_Does_Not_Save_Restaurant_When_Invalid()
        {
            // Arrange
            var mockRepository = new MockRestaurantRepository();
            var controller = new RestaurantController(mockRepository);
            controller.ModelState.AddModelError(string.Empty, "Invalid");

            // Act
            controller.Create(new Restaurant());

            // Assert
            Assert.AreEqual(0, mockRepository.GetAll().Count());
        }
    }
}
