using DataAgenda.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAgenda
{
    public class DatIntermedio
    {
        public List<Intermedio> ReadIntermedios(int id)
        {
            generacion31Entities db = new generacion31Entities();

            List<Intermedio> intermedios = db.Intermedio.Where(x => x.ContactoId == id).ToList();
            return intermedios;
        }
        public Intermedio ReadIntermedio(int id)
        {
            generacion31Entities db = new generacion31Entities();
            Intermedio contacto = db.Intermedio.Where(x => x.Id == id).FirstOrDefault();
            return contacto;
        }
        public void CreateIntermedio(Intermedio intermedio)
        {
            generacion31Entities db = new generacion31Entities();

            db.Intermedio.Add(intermedio);
            db.SaveChanges();
            db.Dispose();
        }
        public void UpdateIntermedio(Intermedio intermedio)
        {
            try
            {
                generacion31Entities db = new generacion31Entities();
                db.Intermedio.AddOrUpdate(intermedio);
                db.SaveChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DelateIntermedio(int id)
        {
            try
            {
                generacion31Entities db = new generacion31Entities();
                Intermedio intermedio = db.Intermedio.Where(x => x.Id == id).FirstOrDefault();
                db.Intermedio.Remove(intermedio);
                db.SaveChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
