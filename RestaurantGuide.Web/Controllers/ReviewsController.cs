using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantGuide.Web.Models;

namespace RestaurantGuide.Web.Controllers
{
    public class ReviewsController : Controller
    {
        private static List<RestaurantReview> _reviews = new List<RestaurantReview>
        {
            new RestaurantReview
            {
                Id = 1,
                Name = "Joe's Pizza Place",
                City = "New York",
                Country = "USA",
                Rating = 9
            },
            new RestaurantReview
            {
                Id = 2,
                Name = "City Wok",
                City = "London",
                Country = "UK",
                Rating = 8
            },
            new RestaurantReview
            {
                Id = 3,
                Name = "La Belle Vue",
                City = "Paris",
                Country = "France",
                Rating = 10
            },
            new RestaurantReview
            {
                Id = 4,
                Name = "Spaggo",
                City = "Rome",
                Country = "Italy",
                Rating = 9
            },
            new RestaurantReview
            {
                Id = 3,
                Name = "Gute Schteltze",
                City = "Berlin",
                Country = "Germany",
                Rating = 7
            }
        };

        // GET: Reviews
        public ActionResult Index()
        {
            var model = _reviews.OrderBy(r => r.Name);

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
            return View();
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
    }
}
