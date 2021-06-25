using CitasWebApp;
using CitasWebApp.Controllers;
using CitasWebApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TestUnit.Model;

namespace TestUnit
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestHomeIndex()
        {
            var obj = new HomeController();
            var actResult = obj.Index() as RedirectToRouteResult;
            string valores = actResult.RouteValues["Action"].ToString();
            Assert.AreEqual(valores, "Login");
        }

        [Test]
        public void TestCrearEspecialidad()
        {
            var obj = new SpecialtyController();
            var actResult = obj.Modificar("0", "EspecialidadTest") as JsonResult;
            var json = JsonConvert.SerializeObject(actResult.Data);
            var br = JsonConvert.DeserializeObject<Respuesta>(json);

            Assert.IsTrue(br.operacion);
        }

        [Test]
        public void TestLoginVista()
        {
            var obj = new AccountController();
            var actResult = obj.Login("") as ViewResult;
            Assert.AreEqual("ok", actResult.ViewData["status"].ToString());
        }

        [Test]
        public void TestModificarEspecialidad()
        {
            var obj = new SpecialtyController();
            var actResult = obj.Modificar("4", "EspecialidadModificar") as JsonResult;
            var json = JsonConvert.SerializeObject(actResult.Data);
            var br = JsonConvert.DeserializeObject<Respuesta>(json);

            Assert.IsTrue(br.operacion);
        }
    }
}
