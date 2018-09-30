using System.ComponentModel.DataAnnotations;

namespace RestaurantGuide.Entities
{
    public class RestaurantReview
    {
        public int Id { get; set; }
        [Required, Range(1, 10)]
        public int Rating { get; set; }
        [Required, StringLength(maximumLength: 1024, MinimumLength = 5)]
        public string Body { get; set; }
        [StringLength(100)]
        public string ReviewerName { get; set; }
        public int RestaurantId { get; set; }
    }
}