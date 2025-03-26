using DataAgenda.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAgenda
{
    public class DatMedioContacto
    {
        generacion31Entities db = new generacion31Entities();
        public List<MediosDeContacto> ReadMediosDeContactos()
        {

            List<MediosDeContacto> mediosDes = db.MediosDeContacto.ToList();
            return mediosDes;
        }
    }
}
