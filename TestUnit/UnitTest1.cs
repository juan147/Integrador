using CitasWebApp.Controllers;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
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
            var actResult = obj.Index() as ViewResult;
            Assert.AreEqual(actResult.ViewName, "");
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
    }
}
