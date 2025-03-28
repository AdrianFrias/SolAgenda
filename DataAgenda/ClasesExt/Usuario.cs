using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAgenda.Modelo
{
    public partial class Usuario
    {
        [Display(Name = "Confirmar Contraseña")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmPassword { get; set; }

        class Atributos
        {
            public int Id { get; set; }
            [Required(ErrorMessage = "Este campo es obligatorio")]
            public string Nombres { get; set; }
            //PAra el usuario vera estos alias
            [Display(Name = "Apellido Paterno")]
            [Required(ErrorMessage = "Este campo es obligatorio")]
            public string Paterno { get; set; }
            [Display(Name = "Apellido Materno")]
            [Required(ErrorMessage = "Este campo es obligatorio")]
            public string Materno { get; set; }
            [Display(Name = "Email")]
            [RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$", ErrorMessage = "Formato incorrecto de correo")]
            //[EmailAddress(ErrorMessage = "Ingresa un correo valido.")]
            [Required(ErrorMessage = "Este campo es obligatorio")]
            public string Correo { get; set; }
            [Display(Name = "Usuario")]
            [Required(ErrorMessage = "Este campo es obligatorio")]
            public string NickName { get; set; }

            [Display(Name = "Contraseña")]
            [Required(ErrorMessage = "Este campo es obligatorio")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required(ErrorMessage = "Este campo es obligatorio")]
            public string Foto { get; set; }
            [Required(ErrorMessage = "Este campo es obligatorio")]
            public string Telefono { get; set; }
        }
    }
}
