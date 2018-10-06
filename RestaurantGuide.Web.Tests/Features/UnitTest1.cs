using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantGuide.Entities;

namespace RestaurantGuide.Web.Tests.Features
{
    [TestClass]
    public class RestaurantRaterTests
    {
        [TestMethod]
        public void Should_Compute_Result_For_One_Review()
        {
            var restaurant = BuildRestaurantAndReviews(ratings: 6);

            var rater = new RestaurantRater(restaurant);
            var result = rater.ComputeRating(10);

            Assert.AreEqual(6, result.Rating);
        }

        [TestMethod]
        public void Should_Compute_Result_For_Two_Reviews()
        {
            var restaurant = BuildRestaurantAndReviews(ratings: new int[] { 4, 6 });

            var rater = new RestaurantRater(restaurant);
            var result = rater.ComputeRating(10);

            Assert.AreEqual(5, result.Rating);
        }

        private Restaurant BuildRestaurantAndReviews(params int[] ratings)
        {
            var restaurant = new Restaurant();
            restaurant.Reviews = ratings
                                 .Select(r => new RestaurantReview { Rating = r })
                                 .ToList();

            return restaurant;
        }
    }
}
