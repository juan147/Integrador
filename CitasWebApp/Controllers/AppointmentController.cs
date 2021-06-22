using CitasWebApp.Models;
using CitasWebApp.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CitasWebApp.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private ApplicationUserManager _userManager;
        private cita objCita = new cita();

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Appointment
        public ActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();
            List<ApplicationUser> users = UserManager.Users.Where(u => u.idTipo.Contains("2")).ToList();

            mymodel.doctores = users;

            return View(mymodel);
        }

        [HttpPost]
        public JsonResult CitasMensuales()
        {
            List<MensualViewModel> datos= objCita.ObtenerCitasMensual();

            return Json(new { data = datos }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CitasEspecialidad()
        {
            List<ValoresViewModel> datos = objCita.ObtenerCitasEspecialidad();

            return Json(new { data = datos }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CitasDiario()
        {
            List<ValoresViewModel> datos = objCita.ObtenerCitasDiarias();

            return Json(new { data = datos }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CitasAnulado()
        {
            List<ValoresViewModel> datos = objCita.ObtenerCitasAnuladas();

            return Json(new { data = datos }, JsonRequestBehavior.AllowGet);
        }
    }
}