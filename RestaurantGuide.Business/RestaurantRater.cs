using System.Linq;
using RestaurantGuide.Business.Interfaces;
using RestaurantGuide.Entities;

namespace RestaurantGuide.Business
{
    public class RestaurantRater
    {
        private Restaurant _restaurant;

        public RestaurantRater(Restaurant restaurant)
        {
            _restaurant = restaurant;
        }

        public RatingResult ComputeRating(IRatingAlgorithm ratingAlgorithm, int numberOfReviews)
        {
            var reviews = _restaurant
                          .Reviews
                          .Take(numberOfReviews)
                          .ToList();

            return ratingAlgorithm.Compute(reviews);
        }
    }
}