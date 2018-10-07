using System.Collections.Generic;
using System.Linq;
using RestaurantGuide.Entities;

namespace RestaurantGuide.Web.Tests.Features
{
    class SimpleRatingAlgorithm : IRatingAlgorithm
    {
        public RatingResult Compute(IList<RestaurantReview> reviews)
        {
            var result = new RatingResult();
            result.Rating = reviews.Average(r => r.Rating);
            return result;
        }
    }
}
