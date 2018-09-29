using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantGuide.Web.Models;
using RestaurantGuide.Entities;
using RestaurantGuide.DataAccess.Repositories;
using System.Configuration;
using RestaurantGuide.DataAccess.Repositories.Interfaces;

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
    }
}
