using DataAgenda.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAgenda
{
    public class DatIntermedio
    {
        generacion31Entities db = new generacion31Entities();
        public List<Intermedio> ReadIntermedios(Contacto contacto)
        {
            List<Intermedio> intermedios = db.Intermedio.Where(x => x.ContactoId == contacto.Id).ToList();
            return intermedios;
        }
        public void CreateIntermedio(Intermedio intermedio)
        {
            db.Intermedio.Add(intermedio);
            db.SaveChanges();
            db.Dispose();
        }
    }
}
