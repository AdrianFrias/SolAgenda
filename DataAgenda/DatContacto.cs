using DataAgenda.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
        public Contacto ReadContacto(int id)
        {
            Contacto contacto = db.Contacto.Where(x => x.Id == id).FirstOrDefault();
            return contacto;
        }
        public void CreateContacto(Contacto con)
        {
            db.Contacto.Add(con);
            db.SaveChanges();
            db.Dispose();
        }
        public void UpdateContacto(Contacto con)
        {
            try
            {
                db.Contacto.AddOrUpdate(con);
                db.SaveChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DelateContacto(int id)
        {
            try
            {
                //Obtener contactos
                Contacto contacto = db.Contacto.Where(x => x.Id == id).FirstOrDefault();
                //Obteenr todos los intermedios asociados a ese contacto
                List<Intermedio> intermedios = db.Intermedio.Where(x => x.ContactoId == contacto.Id).ToList();
                foreach(Intermedio intermedio in intermedios)
                {
                    db.Intermedio.Remove(intermedio);
                }
                db.Contacto.Remove(contacto);
                db.SaveChanges();
                db.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Contacto> SearchContactos(string nombre)
        {
            List<Contacto> contactos = db.Contacto.Where(x => x.Nombre.Contains(nombre)||
            x.Nombre.Contains(nombre) ||
            x.ApPaterno.Contains(nombre) ||
            x.ApMaterno.Contains(nombre)).ToList();
            return contactos;
        }
    }
}
