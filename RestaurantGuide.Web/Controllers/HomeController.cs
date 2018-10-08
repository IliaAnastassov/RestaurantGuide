using System.Linq;
using System.Web.Mvc;
using RestaurantGuide.Business;
using RestaurantGuide.DataAccess.Repositories.Interfaces;
using RestaurantGuide.Entities;
using RestaurantGuide.Web.Models;

namespace RestaurantGuide.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private const int DAY_DURATION = 21600;
        private IRestaurantRepository _restaurantRepository;

        public HomeController(IRestaurantRepository repository)
        {
            _restaurantRepository = repository;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            var restaurants = _restaurantRepository.GetTopRestaurants()
                                                   .Select(restaurant => new RestaurantListViewModel
                                                   {
                                                       Id = restaurant.Id,
                                                       Name = restaurant.Name,
                                                       City = restaurant.City,
                                                       Country = restaurant.Country,
                                                       CountOfReviews = restaurant.Reviews.Count(),
                                                       Rating = new RestaurantRater(restaurant)
                                                                    .ComputeRating(new WeightedRatingAlgorithm(), 10)
                                                                    .Rating
                                                   })
                                                   .ToList();

            return View(restaurants);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [OutputCache(Duration = DAY_DURATION)]
        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult BestRestaurant()
        {
            var bestRestaurant = _restaurantRepository.GetBestRestaurant();

            return PartialView("_BestRestaurant", bestRestaurant);
        }
    }
}