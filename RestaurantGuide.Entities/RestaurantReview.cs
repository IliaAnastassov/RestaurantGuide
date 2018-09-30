using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantGuide.Entities
{
    public class RestaurantReview : IValidatableObject
    {
        public int Id { get; set; }

        [Required, Range(1, 10)]
        public int Rating { get; set; }

        [Required, StringLength(maximumLength: 1024, MinimumLength = 5)]
        public string Body { get; set; }

        [StringLength(100)]
        [Display(Name = "User Name"), DisplayFormat(NullDisplayText = "Anonymous")]
        public string ReviewerName { get; set; }
        public int RestaurantId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Rating <= 2 && ReviewerName.ToLower().StartsWith("eric"))
            {
                yield return new ValidationResult("Stop giving bad results, Eric!");
            }
        }
    }
}