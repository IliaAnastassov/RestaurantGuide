using System.Linq;
using System.Web.Mvc;
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
                                                   .Select(r => new RestaurantListViewModel
                                                   {
                                                       Id = r.Id,
                                                       Name = r.Name,
                                                       City = r.City,
                                                       Country = r.Country,
                                                       CountOfReviews = r.Reviews.Count(),
                                                       Rating = GetRating(r)
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

        private double? GetRating(Restaurant restaurant)
        {
            double? rating = null;

            if (restaurant.Reviews.Any())
            {
                rating = restaurant.Reviews.Average(r => r.Rating);
            }

            return rating;
        }
    }
}