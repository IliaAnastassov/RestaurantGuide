using System.Web.Mvc;
using RestaurantGuide.DataAccess.Repositories;
using RestaurantGuide.Entities;
using RestaurantGuide.Web.Models;

namespace RestaurantGuide.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Restaurant> _repository;

        public HomeController(IRepository<Restaurant> repository)
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