using DataAgenda.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAgenda
{
    public class DatUsuario
    {
        generacion31Entities db = new generacion31Entities();

        public Usuario ValidarUsuarioContraseña(Usuario usu)
        {
            Usuario us = db.Usuario.Where(x => x.NickName == usu.NickName && x.Password == usu.Password).FirstOrDefault();
            return us;
        }
        public Usuario ValidarNickName(Usuario usu)
        {
            Usuario us = db.Usuario.Where(x => x.NickName == usu.NickName).FirstOrDefault();
            return us;
        }

        public void CreateUsuario(Usuario usu)
        {
            try
            {
                db.Usuario.Add(usu);
                db.SaveChanges();
                db.Dispose();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
