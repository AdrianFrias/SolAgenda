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
        public void AgregarContacto(Contacto contacto)
        {
            datos.CreateContacto(contacto);
        }
    }
}
