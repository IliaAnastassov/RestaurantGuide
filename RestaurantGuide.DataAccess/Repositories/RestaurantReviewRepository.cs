using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using RestaurantGuide.DataAccess.Repositories.Interfaces;
using RestaurantGuide.Entities;

namespace RestaurantGuide.DataAccess.Repositories
{
    public class RestaurantReviewRepository : IRestaurantReviewRepository, IRepository<RestaurantReview>
    {
        public RestaurantReview Get(int id)
        {
            using (var db = new RestaurantGuideDb())
            {
                var review = db.RestaurantReviews.Find(id);

                return review;
            }
        }

        public IEnumerable<RestaurantReview> GetReviewsByRestaurant(int restaurantId)
        {
            using (var db = new RestaurantGuideDb())
            {
                var reviews = db.RestaurantReviews
                                .Where(r => r.RestaurantId == restaurantId)
                                .ToList();

                return reviews;
            }
        }

        public IEnumerable<RestaurantReview> GetAll(string filter = null)
        {
            using (var db = new RestaurantGuideDb())
            {
                var reviews = db.RestaurantReviews.ToList();

                return reviews;
            }
        }

        public void Add(RestaurantReview entity)
        {
            using (var db = new RestaurantGuideDb())
            {
                db.RestaurantReviews.Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(RestaurantReview entity)
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
                var review = db.RestaurantReviews.Find(id);
                db.RestaurantReviews.Remove(review);
                db.SaveChanges();
            }
        }
    }
}
