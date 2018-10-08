using System.Collections.Generic;
using System.Linq;
using RestaurantGuide.Business.Interfaces;
using RestaurantGuide.Entities;

namespace RestaurantGuide.Business
{
    public class SimpleRatingAlgorithm : IRatingAlgorithm
    {
        public RatingResult Compute(IList<RestaurantReview> reviews)
        {
            var result = new RatingResult();

            if (reviews.Any())
            {
                result.Rating = reviews.Average(r => r.Rating);
            }
            else
            {
                result.Rating = null;
            }

            return result;
        }
    }
}
