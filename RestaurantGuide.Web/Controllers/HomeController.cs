using System.Linq;
using System.Web.Mvc;
using RestaurantGuide.DataAccess.Repositories.Interfaces;
using RestaurantGuide.Web.Models;

namespace RestaurantGuide.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantRepository _restaurantRepository;

        public HomeController(IRestaurantRepository repository)
        {
            _restaurantRepository = repository;
        }

        public ActionResult Index()
        {
            var restaurants = _restaurantRepository.GetRestaurantsOrderedByRating()
                                                   .Select(r => new RestaurantListViewModel
                                                    {
                                                        Id = r.Id,
                                                        Name = r.Name,
                                                        City = r.City,
                                                        Country = r.Country,
                                                        CountOfReviews = r.Reviews.Count(),
                                                        Rating = r.Reviews.Any() ? (double?)r.Reviews.Average(review => review.Rating) : null
                                                    }).ToList();

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

        [ChildActionOnly]
        public ActionResult BestRestaurant()
        {
            var bestRestaurant = _restaurantRepository.GetBestRestaurant();

            return PartialView("_BestRestaurant", bestRestaurant);
        }
    }
}