using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantGuide.Web.Controllers;
using RestaurantGuide.Web.Models;
using RestaurantGuide.Web.Tests.Mocks;

namespace RestaurantGuide.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var mockRepository = new MockRestaurantRepository(TestData.Restaurants);
            var controller = new HomeController(mockRepository);

            // Act
            var result = controller.Index() as ViewResult;
            var model = result.Model as IEnumerable<RestaurantListViewModel>;

            // Assert
            Assert.AreEqual(10, model.Count());
        }
    }
}
