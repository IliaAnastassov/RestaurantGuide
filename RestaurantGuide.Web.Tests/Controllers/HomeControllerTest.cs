﻿using System.Collections.Generic;
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
            HomeController controller = new HomeController(mockRepository);

            // Act
            ViewResult result = controller.Index() as ViewResult;
            var model = result.Model as IEnumerable<RestaurantListViewModel>;

            // Assert
            Assert.AreEqual(10, model.Count());
        }

        [TestMethod]
        public void About()
        {
            //// Arrange
            //HomeController controller = new HomeController();

            //// Act
            //ViewResult result = controller.About() as ViewResult;

            //// Assert
            //Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void Contact()
        {
            //// Arrange
            //HomeController controller = new HomeController();

            //// Act
            //ViewResult result = controller.Contact() as ViewResult;

            //// Assert
            //Assert.IsNotNull(result);
        }
    }
}
