﻿using System;
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
        private IRepository<Restaurant> _restaurantRepository;
        private IRepository<RestaurantReview> _reviewRepository;

        public ReviewsController(IRepository<Restaurant> restaurantRepository, IRepository<RestaurantReview> reviewRepository)
        {
            _restaurantRepository = restaurantRepository;
            _reviewRepository = reviewRepository;
        }

        // GET: Reviews
        public ActionResult Index()
        {
            //var model = _repository.OrderBy(r => r.Rating);

            return View();
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
            //var model = _repository.SingleOrDefault(r => r.Id == id);

            return View();
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            //var model = _repository.SingleOrDefault(r => r.Id == id);
            //if (TryUpdateModel(model))
            //{
            //    return RedirectToAction(nameof(Index));
            //}

            return View();
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
