using System.Collections.Generic;
using RestaurantGuide.Entities;

namespace RestaurantGuide.Business.Interfaces
{
    public interface IRatingAlgorithm
    {
        RatingResult Compute(IList<RestaurantReview> reviews);
    }
}
