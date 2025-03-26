using DataAgenda;
using DataAgenda.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioAgenda
{
    public class NegocioUsuario
    {
        DatUsuario datos = new DatUsuario();
        public Usuario ValidarUsuarioContraseña(Usuario usu)
        {
            Usuario us = datos.ValidarUsuarioContraseña(usu);
            if (us == null)
            {
                throw new Exception("El usuario/Contraseña son incorrectos");
            }
            return us;
        }
        public void AgregarUsuario(Usuario usu)
        {
            if (datos.ValidarNickName(usu) == null)
            {
                datos.CreateUsuario(usu);
            }
            else
            {
                throw new Exception($"El usuario {usu.NickName} ya existe");
            }
        }
    }
}
