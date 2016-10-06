using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pagination.Hubs;
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
        
        public ActionResult Chat()
        {
            return View();
        }

        public ActionResult Method()
        {
            return View();
        }
       /* [HttpPost]
        public ActionResult Chat(UserInfo userInfo)
        {
            List<UserInfo> list = new List<UserInfo>();
            list.Add(userInfo);
            SendMessage("New user has connected!");
            return RedirectToAction("Chat");
        }
        */
        private void SendMessage(string message)
        {
            // Получаем контекст хаба
            var context =
                Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            // отправляем сообщение
            context.Clients.All.displayMessage(message);
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