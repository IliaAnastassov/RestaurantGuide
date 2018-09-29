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
            using (var db = new RestaurantGuideDb())
            {
                var restaurant = db.Restaurants.Find(id);
                return restaurant;
            }
        }

        public IEnumerable<Restaurant> GetAll(string filter)
        {
            using (var db = new RestaurantGuideDb())
            {
                var restaurants = db.Restaurants
                                    .AsNoTracking()
                                    .Include(r => r.Reviews)
                                    .Where(r => string.IsNullOrEmpty(filter) || r.Name.ToLower().Contains(filter.ToLower()))
                                    .OrderBy(r => r.Name)
                                    .ToList();

                return restaurants;
            }
        }

        public IEnumerable<Restaurant> GetTopRestaurants()
        {
            using (var db = new RestaurantGuideDb())
            {
                var restaurants = db.Restaurants
                                    .AsNoTracking()
                                    .Include(r => r.Reviews)
                                    .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                                    .Take(10)
                                    .ToList();

                return restaurants;
            }
        }

        public void Add(Restaurant entity)
        {
            using (var db = new RestaurantGuideDb())
            {
                db.Restaurants.Add(entity);
                db.SaveChanges();
            }
        }

        public void Edit(Restaurant entity)
        {
            using (var db = new RestaurantGuideDb())
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new RestaurantGuideDb())
            {
                var restaurant = db.Restaurants.Find(id);
                db.Restaurants.Remove(restaurant);
                db.SaveChanges();
            }
        }

        public Restaurant GetBestRestaurant()
        {
            using (var context = new RestaurantGuideDb())
            {
                var restaurant = context.Restaurants
                                        .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                                        .FirstOrDefault();

                return restaurant;
            }
        }
    }
}
