using System.Web.Mvc;
using RestaurantGuide.DataAccess.Repositories.Interfaces;
using RestaurantGuide.Entities;

namespace RestaurantGuide.Web.Controllers
{
    public class ReviewsController : Controller
    {
        private IRestaurantReviewRepository _reviewRepository;
        private IRestaurantRepository _restaurantRepository;

        public ReviewsController(IRestaurantReviewRepository reviewRepository, IRestaurantRepository restaurantRepository)
        {
            _reviewRepository = reviewRepository;
            _restaurantRepository = restaurantRepository;
        }

        // GET: Reviews
        public ActionResult Index(int restaurantId)
        {
            var restaurant = _restaurantRepository.Get(restaurantId);

            if (restaurant == null)
            {
                return HttpNotFound();
            }

            return View(restaurant);
        }

        [HttpGet]
        public ActionResult Add(int restaurantId)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(RestaurantReview review)
        {
            if (ModelState.IsValid)
            {
                _reviewRepository.Add(review);
                return RedirectToAction(nameof(Index), new { restaurantId = review.RestaurantId });
            }

            return View(review);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var review = _reviewRepository.Get(id);

            return View(review);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "ReviewerName")]RestaurantReview review)
        {
            if (ModelState.IsValid)
            {
                _reviewRepository.Update(review);
                return RedirectToAction(nameof(Index), new { restaurantId = review.RestaurantId });
            }

            return View(review);
        }
    }
}
