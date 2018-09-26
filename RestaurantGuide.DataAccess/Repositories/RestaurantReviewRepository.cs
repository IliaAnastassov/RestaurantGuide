using System.Collections.Generic;
using System.Linq;
using RestaurantGuide.DataAccess.Repositories.Interfaces;
using RestaurantGuide.Entities;

namespace RestaurantGuide.DataAccess.Repositories
{
    public class RestaurantReviewRepository : IRestaurantReviewRepository, IRepository<RestaurantReview>
    {
        public RestaurantReview Get(int id)
        {
            using (var context = new RestaurantGuideDb())
            {
                var review = context.RestaurantReviews.Find(id);
                return review;
            }
        }

        public IEnumerable<RestaurantReview> GetAll()
        {
            using (var context = new RestaurantGuideDb())
            {
                var reviews = context.RestaurantReviews
                                     .ToList();

                return reviews;
            }
        }
    }
}
