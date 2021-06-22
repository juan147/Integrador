using CitasWebApp.Models;
using CitasWebApp.Reports;
using CrystalDecisions.CrystalReports.Engine;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CitasWebApp.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        cita objCita = new cita();

        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Reporte()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult ReporteExport()
        {
            return View();
        }

        public ActionResult ReportePdf(string fecha1, string fecha2, int tipo)
        {
            DateTime dfecha1 = DateTime.Parse(fecha1);
            DateTime dfecha2 = DateTime.Parse(fecha2);

            double vdias = (dfecha2 - dfecha1).TotalDays;

            List<cita> citas = objCita.ObtenerCitasFechas(dfecha1, dfecha2);

            int vtipo = vdias > 10 ? 2 : 1;

            dsReporte ds = new dsReporte();
            DataTable tbcita = ds.Citas;

            foreach(var x in citas)
            {
                tbcita.Rows.Add(x.fecha.ToString(), x.paciente.nombres, x.fecha.Value.ToString("MMMM", CultureInfo.CreateSpecificCulture("es")).ToUpper(),
                     x.doctore.nombres, x.tipocita.descripcion, x.fecha.Value.Month, x.doctore.especialidade.descripcion
                );
            }

            ReportDocument rd = new ReportDocument();

            if (tipo == 1)
            {
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "reporte1.rpt"));
            }
            else if (tipo == 2)
            {
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "reporte2.rpt"));
            }
            else
            {
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "reporte3.rpt"));
            }



            rd.SetDataSource(ds);

            rd.SetParameterValue("@vUsuario", User.Identity.GetUserName());
            rd.SetParameterValue("@vTipo", vtipo);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "reporte.pdf");
        }

        public ActionResult ReporteExcel(string fecha1, string fecha2, int tipo)
        {
            DateTime dfecha1 = DateTime.Parse(fecha1);
            DateTime dfecha2 = DateTime.Parse(fecha2);

            double vdias = (dfecha2 - dfecha1).TotalDays;

            List<cita> citas = objCita.ObtenerCitasFechas(dfecha1, dfecha2);

            int vtipo = vdias > 10 ? 2 : 1;

            dsReporte ds = new dsReporte();
            DataTable tbcita = ds.Citas;

            foreach (var x in citas)
            {
                tbcita.Rows.Add(x.fecha.ToString(), x.paciente.nombres, x.fecha.Value.ToString("MMMM", CultureInfo.CreateSpecificCulture("es")).ToUpper(),
                     x.doctore.nombres, x.tipocita.descripcion, x.fecha.Value.Month, x.doctore.especialidade.descripcion
                );
            }

            ReportDocument rd = new ReportDocument();
            if (tipo == 1)
            {
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "reporte1.rpt"));
            }
            else if (tipo == 2)
            {
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "reporte2.rpt"));
            }
            else
            {
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "reporte3.rpt"));
            }


            rd.SetDataSource(ds);

            rd.SetParameterValue("@vUsuario", User.Identity.GetUserName());
            rd.SetParameterValue("@vTipo", vtipo);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();


            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.Excel);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/excel", "reporte.xls");
        }
    }
}