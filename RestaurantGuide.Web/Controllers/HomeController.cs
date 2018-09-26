using System.Web.Mvc;
using RestaurantGuide.DataAccess.Repositories;
using RestaurantGuide.DataAccess.Repositories.Interfaces;
using RestaurantGuide.Entities;
using RestaurantGuide.Web.Models;

namespace RestaurantGuide.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantRepository _repository;

        public HomeController(IRestaurantRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var model = _repository.GetAll();

            return View(model);
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
    }
}