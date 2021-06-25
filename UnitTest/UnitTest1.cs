using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using CitasWebApp.Controllers;
using CitasWebApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using UnitTest.Model;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestHomeIndex()
        {
            var obj = new HomeController();
            var actResult = obj.Index() as ViewResult;
            Assert.AreEqual(actResult.ViewName, "");
        }

        [TestMethod]
        public void TestCrearEspecialidad()
        {
            var obj = new SpecialtyController();
            var actResult = obj.Modificar("0","EspecialidadTest") as JsonResult;
            var json = JsonConvert.SerializeObject(actResult.Data);
            var br = JsonConvert.DeserializeObject<Respuesta>(json);

            Assert.IsTrue(br.operacion);
        }

    }
}
