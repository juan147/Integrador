using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CitasWebApp.Models
{
    public partial class sala
    {
        public IEnumerable<sala> ListarSalas()
        {
            Entities db = new Entities();
            IEnumerable<sala> list;
            list = db.salas.ToList();

            return list;
        }

        public bool ModificarSala(sala obj)
        {
            bool respuesta = false;

                Entities db = new Entities();
                sala vsala = db.salas.Find(obj.idSala);
                vsala.descripcion = obj.descripcion;
                db.Entry(vsala).State = EntityState.Modified;
                db.SaveChanges();
                respuesta = true;

            return respuesta;
        }

        public bool CrearSala(sala obj)
        {
            bool respuesta = false;

                Entities db = new Entities();
                sala vsala = new sala()
                {
                    descripcion = obj.descripcion,
                    estado = "1"
                };
                db.salas.Add(vsala);
                db.SaveChanges();
                respuesta = true;

            return respuesta;
        }

        public bool DeshabilitarSala(sala obj)
        {
            bool respuesta = false;
   
                Entities db = new Entities();
                sala vsala = db.salas.Find(obj.idSala);
                vsala.estado = obj.estado;
                db.Entry(vsala).State = EntityState.Modified;
                db.SaveChanges();
                respuesta = true;


            return respuesta;
        }
    }
}