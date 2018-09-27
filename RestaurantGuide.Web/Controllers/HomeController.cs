using System.Linq;
using System.Web.Mvc;
using RestaurantGuide.DataAccess.Repositories.Interfaces;
using RestaurantGuide.Web.Models;

namespace RestaurantGuide.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantRepository _restaurantRepository;
        private IRestaurantReviewRepository _reviewRepository;

        public HomeController(IRestaurantRepository repository, IRestaurantReviewRepository reviewRepository)
        {
            _restaurantRepository = repository;
            _reviewRepository = reviewRepository;
        }

        public ActionResult Index()
        {
            var topRestaurants = _restaurantRepository.GetTopTenRestaurants();

            return View(topRestaurants);
        }

        public ActionResult About()
        {
            var model = new AboutModel();
            model.Name = "Dildo Schwaggins";
            model.Description = "A mighty developer from middle earth";
            model.Location = "Dildoland, The Shire";

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult BestRestaurant()
        {
            var bestRestaurantId = _reviewRepository.GetAll()
                                                    .OrderByDescending(r => r.Rating)
                                                    .FirstOrDefault()
                                                    .Id;

            var bestRestaurant = _restaurantRepository.Get(bestRestaurantId);

            return PartialView("_BestRestaurant", bestRestaurant);
        }
    }
}