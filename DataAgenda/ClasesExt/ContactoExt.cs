using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAgenda.Modelo
{
    [MetadataType(typeof(Atributos))]
    public partial class Contacto
    {
        public DateTime FechaNacimiento { get; set; }
        class Atributos
        {
            public int Id { get; set; }
            public string Nombre { get; set; }

            [Display(Name = "Apellido Paterno")]
            public string ApPaterno { get; set; }

            [Display(Name = "Apellido Materno")]
            public string ApMaterno { get; set; }
            public int UsuarioId { get; set; }

            [Display(Name = "Fecha de Nacimiento")]
            public string Edad { get; set; }
            public string Foto { get; set; }
        }
    }
}
