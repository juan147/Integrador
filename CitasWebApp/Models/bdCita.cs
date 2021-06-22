using CitasWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CitasWebApp.Models
{
    public partial class cita
    {
        public List<cita> ObtenerCitasFechas(DateTime dfecha1, DateTime dfecha2)
        {
            Entities db = new Entities();
            List<cita> citas = db.citas.Where(x => x.fecha >= dfecha1 && x.fecha <= dfecha2).OrderBy(x => x.fecha).ToList();

            return citas;
        }

        public List<MensualViewModel> ObtenerCitasMensual()
        {
            Entities db = new Entities();
            string query = "select month(fecha) as mes, count(*) as valor from citas where year(fecha)=2021 group by month(fecha)";
            var result = db.Database.SqlQuery<MensualViewModel>(query).ToList();

            return result;
        }

        public List<ValoresViewModel> ObtenerCitasEspecialidad()
        {
            Entities db = new Entities();
            string query = "select e.descripcion as cate,count(*) as valor from citas c " +
                            "inner join doctores d on c.idDoctor = d.id inner join salas e on d.idEspecialidad = e.idEspecialidad " +
                            "where c.estado='1' and year(fecha) = 2021 group by e.descripcion";
            var result = db.Database.SqlQuery<ValoresViewModel>(query).ToList();

            return result;
        }

        public List<ValoresViewModel> ObtenerCitasDiarias()
        {
            Entities db = new Entities();
            string query = "select LTRIM(STR(day(fecha),2)) as cate,count(*) as valor from citas c where c.estado='1' and year(fecha) = 2021 and month(fecha)= 5 group by fecha";
            var result = db.Database.SqlQuery<ValoresViewModel>(query).ToList();

            return result;
        }

        public List<ValoresViewModel> ObtenerCitasAnuladas()
        {
            Entities db = new Entities();
            string query = "select LTRIM(STR(month(fecha),2)) as cate,count(*) as valor from citas c where c.estado='0' and year(fecha) = 2021 group by month(fecha)";
            var result = db.Database.SqlQuery<ValoresViewModel>(query).ToList();

            return result;
        }
    }
}