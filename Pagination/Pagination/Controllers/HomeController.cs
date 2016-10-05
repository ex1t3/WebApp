using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pagination.Models;

namespace Pagination.Controllers
{

    public class HomeController : Controller
    {
        MainMenuContext db = new MainMenuContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Chat()
        {
            return View();
        }

        public ActionResult Menu()
        {
            var menuItems = db.mainMenus.ToList();
            return PartialView(menuItems);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}