using System.Collections.Generic;
using System.Linq;
using RestaurantGuide.DataAccess.Repositories.Interfaces;
using RestaurantGuide.Entities;

namespace RestaurantGuide.DataAccess.Repositories
{
    public class InMemoryRestaurantRepository : IRestaurantRepository, IRepository<Restaurant>
    {
        private static List<Restaurant> _restaurants = new List<Restaurant>
        {
            new Restaurant { Id = 1, Name = "Joe's Pizza Place", City = "New York", Country = "USA" },
            new Restaurant { Id = 2, Name = "City Wok", City = "London", Country = "UK" },
            new Restaurant { Id = 3, Name = "La Belle Vue", City = "Paris", Country = "France" },
            new Restaurant
            {
                Id = 4,
                Name = "Spaggo",
                City = "Rome",
                Country = "Italy",
                Reviews = new List<RestaurantReview>
                {
                    new RestaurantReview { Id = 1, Rating = 9, Body = "Genuine Italian food - a must visit for all italian food lovers.", ReviewerName = "Jimmy", RestaurantId = 4 },
                    new RestaurantReview { Id = 2, Rating = 10, Body = "Food, wine and service are impecable!", ReviewerName = "Melissa", RestaurantId = 4 }
                }
            },
            new Restaurant
            {
                Id= 5,
                Name = "Gute Schteltze",
                City = "Berlin",
                Country = "Germany",
                Reviews = new List<RestaurantReview>
                {
                    new RestaurantReview { Id = 3, Rating = 8, Body = "Very nice place!", ReviewerName = "Jannet", RestaurantId = 5 }
                }
            }
        };

        public Restaurant Get(int id)
        {
            return _restaurants.Find(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        public IEnumerable<Restaurant> GetTopTenRestaurants()
        {
            return _restaurants.OrderByDescending(r => r.Reviews?.Average(reveiw => reveiw?.Rating))
                               .Take(10);
        }
    }
}
