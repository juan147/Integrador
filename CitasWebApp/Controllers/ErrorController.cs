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
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return View();
        }
        public ActionResult Error401()
        {
            ViewBag.Title = "Error 401";
            Response.StatusCode = (int)HttpStatusCode.Unauthorized;

            return View();
        }

        public ActionResult Error404()
        {
            ViewBag.Title = "Error 404";
            Response.StatusCode = (int)HttpStatusCode.Unauthorized;

            return View();
        }
    }
}