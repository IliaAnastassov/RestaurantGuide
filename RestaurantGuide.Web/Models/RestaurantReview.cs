using System.ComponentModel.DataAnnotations;

namespace RestaurantGuide.Web.Models
{
    public class RestaurantReview
    {
        public int Id { get; set; }
        [Required, MaxLength(100, ErrorMessage = "The name is too long.")]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required, Range(0, 10, ErrorMessage = "Please specify a rating between 0 and 10.")]
        public int Rating { get; set; }
    }
}