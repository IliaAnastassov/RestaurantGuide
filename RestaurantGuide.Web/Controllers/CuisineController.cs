using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantGuide.Web.Controllers
{
    public class CuisineController : Controller
    {
        public ActionResult Search(string name)
        {
            var message = Server.HtmlEncode(name);
            return Content(message);
        }
    }
}