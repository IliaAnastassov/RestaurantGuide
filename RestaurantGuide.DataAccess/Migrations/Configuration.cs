namespace RestaurantGuide.DataAccess.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using RestaurantGuide.Entities;

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
                new Restaurant { Name = "Spaggo", City = "Rome", Country = "Italy" },
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
