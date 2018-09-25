using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantGuide.Web.Models;
using RestaurantGuide.Entities;
using RestaurantGuide.DataAccess.Repositories;
using System.Configuration;

namespace RestaurantGuide.Web.Controllers
{
    public class ReviewsController : Controller
    {
        private static List<RestaurantReview> _reviews = new List<RestaurantReview>
        {
            new RestaurantReview
            {
                Id = 1,
                Rating = 9
            },
            new RestaurantReview
            {
                Id = 2,
                Rating = 8
            },
            new RestaurantReview
            {
                Id = 3,
                Rating = 10
            },
            new RestaurantReview
            {
                Id = 4,
                Rating = 9
            },
            new RestaurantReview
            {
                Id = 5,

                Rating = 7
            }
        };
        private static List<Restaurant> _restaurants = new List<Restaurant>
        {
            new Restaurant
            {
                Id = 1,
                Name = "Joe's Pizza Place",
                City = "New York",
                Country = "USA"
            },
            new Restaurant
            {
                Id = 2,
                Name = "City Wok",
                City = "London",
                Country = "UK"
            },
            new Restaurant
            {
                Id = 3,
                Name = "La Belle Vue",
                City = "Paris",
                Country = "France"
            },
            new Restaurant
            {
                Id = 4,
                Name = "Spaggo",
                City = "Rome",
                Country = "Italy"
            },
            new Restaurant
            {
                Id = 5,
                Name = "Gute Schteltze",
                City = "Berlin",
                Country = "Germany"
            },
        };

        private IRepository<RestaurantReview> _repository;

        public ReviewsController(IRepository<RestaurantReview> repository)
        {
            _repository = repository;
        }

        // GET: Reviews
        public ActionResult Index()
        {
            var model = _reviews.OrderBy(r => r.Rating);

            return View(model);
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reviews/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _reviews.SingleOrDefault(r => r.Id == id);

            return View(model);
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = _reviews.SingleOrDefault(r => r.Id == id);
            if (TryUpdateModel(model))
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reviews/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [ChildActionOnly]
        public ActionResult BestReview()
        {
            var model = _reviews.OrderByDescending(r => r.Rating)
                                .FirstOrDefault();

            return PartialView("_BestReview", model);
        }
    }
}
