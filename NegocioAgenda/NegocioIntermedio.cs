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
        public List<Intermedio> ObtenerTodosIntermedios(int id)
        {
            List<Intermedio> medios = datos.ReadIntermedios(id);
            return medios;
        }
        public Intermedio ObtenerIntermedio(int id)
        {
            Intermedio intermedio = datos.ReadIntermedio(id);
            return intermedio;
        }
        public void AgregarIntermedio(Intermedio intermedio)
        {
            datos.CreateIntermedio(intermedio);
        }
        public void ActualiarIntermedio(Intermedio intermedio)
        {
            datos.UpdateIntermedio(intermedio);
        }
        public void EliminarIntermedio(int id)
        {
            datos.DelateIntermedio(id);
        }
    }
}
