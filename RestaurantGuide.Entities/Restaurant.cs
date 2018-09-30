using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantGuide.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required, StringLength(100)]
        public string City { get; set; }
        [Required, StringLength(100)]
        public string Country { get; set; }

        public virtual ICollection<RestaurantReview> Reviews { get; set; }
    }
}
