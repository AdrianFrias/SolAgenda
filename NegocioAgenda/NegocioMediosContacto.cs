using DataAgenda;
using DataAgenda.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioAgenda
{
    public class NegocioMediosContacto
    {
        DatMedioContacto datos = new DatMedioContacto();
        public List<MediosDeContacto> ObtenerTodosMedios()
        {
            List<MediosDeContacto> medios = datos.ReadMediosDeContactos();
            return medios;
        }
    }
}
