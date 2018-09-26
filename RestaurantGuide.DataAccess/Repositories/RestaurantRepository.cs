using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RestaurantGuide.DataAccess.Repositories.Interfaces;
using RestaurantGuide.Entities;

namespace RestaurantGuide.DataAccess.Repositories
{
    public class RestaurantRepository : IRestaurantRepository, IRepository<Restaurant>
    {
        public Restaurant Get(int id)
        {
            using (var context = new RestaurantGuideDb())
            {
                var restaurant = context.Restaurants.Find(id);
                return restaurant;
            }
        }

        public IEnumerable<Restaurant> GetAll()
        {
            using (var context = new RestaurantGuideDb())
            {
                var restaurants = context.Restaurants
                                         .AsNoTracking()
                                         .OrderBy(r => r.Name)
                                         .ToList();

                return restaurants;
            }
        }

        public IEnumerable<Restaurant> GetTopTenRestaurants()
        {
            using (var context = new RestaurantGuideDb())
            {
                var restaurants = context.Restaurants
                                         .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                                         .Take(10)
                                         .ToList();

                return restaurants;
            }
        }
    }
}
