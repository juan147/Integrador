using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CitasWebApp.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Error500()
        {
            ViewBag.Title = "Error 500";


            return View();
        }
        public ActionResult Error401()
        {
            ViewBag.Title = "Error 401";


            return View();
        }

        public ActionResult Error404()
        {
            ViewBag.Title = "Error 404";

            return View();
        }
    }
}