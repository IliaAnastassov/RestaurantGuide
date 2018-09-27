using System.Collections.Generic;
using RestaurantGuide.DataAccess.Repositories.Interfaces;
using RestaurantGuide.Entities;

namespace RestaurantGuide.DataAccess.Repositories
{
    public class InMemoryRestaurantReviewRepository : IRestaurantReviewRepository, IRepository<RestaurantReview>
    {
        private static List<RestaurantReview> _reviews = new List<RestaurantReview>
        {
            new RestaurantReview { Id = 1, Rating = 9, Body = "Genuine Italian food - a must visit for all italian food lovers.", ReviewerName = "Jimmy", RestaurantId = 4 },
            new RestaurantReview { Id = 2, Rating = 10, Body = "Food, wine and service are impecable!", ReviewerName = "Melissa", RestaurantId = 4 },
            new RestaurantReview { Id = 3, Rating = 8, Body = "Very nice place!", ReviewerName = "Jannet", RestaurantId = 5 }
        };

        public RestaurantReview Get(int id)
        {
            return _reviews.Find(r => r.Id == id);
        }

        public IEnumerable<RestaurantReview> GetAll()
        {
            return _reviews;
        }
    }
}
