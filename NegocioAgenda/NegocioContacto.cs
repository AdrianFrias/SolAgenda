using DataAgenda;
using DataAgenda.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioAgenda
{
    public class NegocioContacto
    {
        DatContacto datos = new DatContacto();

        public List<Contacto> ObtenerTodos(Usuario us)
        {
            List<Contacto> contactos = datos.ReadContactos(us);
            return contactos;
        }
        public Contacto ObtenerContacto(int id)
        {
            Contacto contacto = datos.ReadContacto(id);
            return contacto;
        }
        public void AgregarContacto(Contacto contacto)
        {
            datos.CreateContacto(contacto);
        }
        public void ActualizarContacto(Contacto contacto)
        {
            datos.UpdateContacto(contacto);
        }
        public void EliminarContacto(int id)
        {
            datos.DelateContacto(id);
        }
        public List<Contacto> BuscarContacto(string nombre)
        {
            return datos.SearchContactos(nombre);
        }
    }
}
