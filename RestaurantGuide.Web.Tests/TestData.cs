using System.Collections.Generic;
using RestaurantGuide.Entities;

namespace RestaurantGuide.Web.Tests
{
    class TestData
    {
        public static ICollection<Restaurant> Restaurants
        {
            get
            {
                var restaurants = new List<Restaurant>();

                for (int i = 0; i < 100; i++)
                {
                    var restaurant = new Restaurant();
                    restaurant.Reviews = new List<RestaurantReview>
                    {
                        new RestaurantReview {Rating = 6 }
                    };
                    restaurants.Add(restaurant);
                }

                return restaurants;
            }
        }
    }
}
