using System.Collections.Generic;
using RestaurantGuide.Entities;

namespace RestaurantGuide.Web.Tests.Features
{
    public interface IRatingAlgorithm
    {
        RatingResult Compute(IList<RestaurantReview> reviews);
    }
}
