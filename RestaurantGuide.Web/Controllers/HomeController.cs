using System.Web.Mvc;
using RestaurantGuide.Web.Models;

namespace RestaurantGuide.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var controller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];
            var id = RouteData.Values["id"];

            var message = $"{controller}::{action}/{id}";

            ViewBag.Message = message;

            return View();
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