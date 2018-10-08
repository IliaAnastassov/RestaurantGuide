using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantGuide.Entities;
using RestaurantGuide.Business;

namespace RestaurantGuide.Business.Tests
{
    [TestClass]
    public class RestaurantRaterTests
    {
        [TestMethod]
        public void Computes_Simple_Result_For_One_Review()
        {
            var restaurant = BuildRestaurantAndReviews(6);

            var rater = new RestaurantRater(restaurant);
            var result = rater.ComputeRating(new SimpleRatingAlgorithm(), 10);

            Assert.AreEqual(6, result.Rating);
        }

        [TestMethod]
        public void Computes_Simple_Result_For_Two_Reviews()
        {
            var restaurant = BuildRestaurantAndReviews(4, 6);

            var rater = new RestaurantRater(restaurant);
            var result = rater.ComputeRating(new SimpleRatingAlgorithm(), 10);

            Assert.AreEqual(5, result.Rating);
        }

        [TestMethod]
        public void Computes_Simple_Result_For_The_First_N_Reviews()
        {
            var restaurant = BuildRestaurantAndReviews(2, 3, 4, 8, 9, 10);

            var rater = new RestaurantRater(restaurant);
            var result = rater.ComputeRating(new SimpleRatingAlgorithm(), 3);

            Assert.AreEqual(3, result.Rating);
        }

        [TestMethod]
        public void Computes_Weighted_Result_For_Two_Reviews()
        {
            var restaurant = BuildRestaurantAndReviews(5, 8);

            var rater = new RestaurantRater(restaurant);
            var result = rater.ComputeRating(new WeightedRatingAlgorithm(), 10);

            Assert.AreEqual(6, result.Rating);
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
