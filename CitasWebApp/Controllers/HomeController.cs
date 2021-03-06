using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CitasWebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index() 
        {
            try
            {
                if (Session["TipoUser"] == null)
                {
                    return RedirectToAction("Login", "Account");
                }

                return View();
            }
            catch
            {
                return RedirectToAction("Login", "Account");
            }
            
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