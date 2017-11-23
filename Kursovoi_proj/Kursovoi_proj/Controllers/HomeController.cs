using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPortal_Music.Contracts.DataContracts;
using WebPortal_Music.DAL.DataBase;

namespace Kursovoi_proj.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new WebPortalContext())
            {
                context.User.Add(new Users() { UsersID = 1, FirstName = "About", LastName = "s",Email = "dimkin_7@mail.ru", Phone = 123 });
                var a = context.User;
            }
            return View();
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