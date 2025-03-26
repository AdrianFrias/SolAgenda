using DataAgenda.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAgenda
{
    public class DatContacto
    {
        generacion31Entities db = new generacion31Entities();

        public List<Contacto> ReadContactos(Usuario us)
        {
            List<Contacto> contactos = db.Contacto.Where(x => x.UsuarioId == us.Id).ToList();
            return contactos;
        }
        public void CreateContacto(Contacto con)
        {
            db.Contacto.Add(con);
            db.SaveChanges();
            db.Dispose();
        }
    }
}
