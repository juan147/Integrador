using CitasWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CitasWebApp.Controllers
{
    [Authorize]
    public class RoomController : Controller
    {
        sala objSala = new sala();

        // GET: Specialty
        public ActionResult Index()
        {

            IEnumerable<sala> list = objSala.ListarSalas();

            return View(list);
        }

        [HttpPost]
        public JsonResult Modificar(string id, string descripcion)
        {
            objSala.idSala = int.Parse(id);
            objSala.descripcion = descripcion;

            bool respuesta = false;

            if (objSala.idSala == 0)
            {
                respuesta = objSala.CrearSala(objSala);
            }
            else
            {
                respuesta = objSala.ModificarSala(objSala);
            }

            return Json(new { operacion = respuesta, errMsg = "" });

        }

        [HttpPost]
        public JsonResult Deshabilitar(string id, string estado)
        {
            objSala.idSala = int.Parse(id);
            objSala.estado = estado == "1" ? "0" : "1";

            bool respuesta = objSala.DeshabilitarSala(objSala);

            return Json(new { operacion = respuesta, errMsg = "" });

        }

        [HttpGet]
        public JsonResult Listar()
        {
            IEnumerable<sala> list = objSala.ListarSalas();

            return Json(new { data = list }, JsonRequestBehavior.AllowGet);

        }
    }
}