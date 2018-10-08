using System.Collections.Generic;
using System.Linq;
using RestaurantGuide.Business.Interfaces;
using RestaurantGuide.Entities;

namespace RestaurantGuide.Business
{
    public class WeightedRatingAlgorithm : IRatingAlgorithm
    {
        public RatingResult Compute(IList<RestaurantReview> reviews)
        {
            var result = new RatingResult();

            if (reviews.Any())
            {
                var counter = 0;
                var total = 0;

                for (int i = 0; i < reviews.Count; i++)
                {
                    if (i < reviews.Count / 2)
                    {
                        total += reviews[i].Rating * 2;
                        counter += 2;
                    }
                    else
                    {
                        total += reviews[i].Rating;
                        counter++;
                    }
                }

                result.Rating = total / counter;
            }
            else
            {
                result.Rating = null;
            }

            return result;
        }
    }
}
