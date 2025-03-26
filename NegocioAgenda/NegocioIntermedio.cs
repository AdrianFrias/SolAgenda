using DataAgenda;
using DataAgenda.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioAgenda
{
    public class NegocioIntermedio
    {
        DatIntermedio datos = new DatIntermedio();
        public List<Intermedio> ObtenerTodosIntermedios(Contacto con)
        {
            List<Intermedio> medios = datos.ReadIntermedios(con);
            return medios;
        }
        public void AgregarIntermedio(Intermedio intermedio)
        {
            datos.CreateIntermedio(intermedio);
        }
    }
}
