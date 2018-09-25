using System.Collections.Generic;
using System.Data.Entity.Migrations;
using RestaurantGuide.Entities;

namespace RestaurantGuide.DataAccess.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<RestaurantGuideDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RestaurantGuideDb context)
        {
            context.Restaurants.AddOrUpdate(r => r.Name,
                new Restaurant { Name = "Joe's Pizza Place", City = "New York", Country = "USA" },
                new Restaurant { Name = "City Wok", City = "London", Country = "UK" },
                new Restaurant { Name = "La Belle Vue", City = "Paris", Country = "France" },
                new Restaurant
                {
                    Name = "Spaggo",
                    City = "Rome",
                    Country = "Italy",
                    Reviews = new List<RestaurantReview>
                    {
                        new RestaurantReview { Rating = 9, Body = "Genuine Italian food - a must visit for all italian food lovers." },
                        new RestaurantReview { Rating = 10, Body = "Food, wine and service are impecable!" }
                    }
                },
                new Restaurant
                {
                    Name = "Gute Schteltze",
                    City = "Berlin",
                    Country = "Germany",
                    Reviews = new List<RestaurantReview>
                    {
                        new RestaurantReview { Rating = 8, Body = "Very nice place!" }
                    }
                });
        }
    }
}
