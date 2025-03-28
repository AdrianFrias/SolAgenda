using DataAgenda.Modelo;
using NegocioAgenda;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAgenda.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Home

        NegocioUsuario neg = new NegocioUsuario();
        public ActionResult Login()
        {
            return View("Login");
        }
        public ActionResult ValidarCredenciales(Usuario user)
        {
            try
            {
                Usuario us = neg.ValidarUsuarioContraseña(user);

                Session["Usuario"] = us;
            
                return RedirectToAction("Index","Contacto");
            }
            catch(Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Login");
            }
        }
        public ActionResult CerrarSesion()
        {
            Session["Usuario"] = null;
            return View("Login");
        }
        public ActionResult VistaUsuario(Usuario user)
        {
            return View("VistaAgregarUsuario");
        }
        public ActionResult AgregarUsuario(Usuario user, HttpPostedFileBase FileFoto)
        {
            try
            {
                if (FileFoto == null)
                {
                    user.Foto = "default.png";
                }
                else
                {
                    string rutaArchivo = Path.Combine(Server.MapPath("~/FotosContactos"), FileFoto.FileName);
                    FileFoto.SaveAs(rutaArchivo);
                    user.Foto = FileFoto.FileName;
                }
                neg.AgregarUsuario(user);
                TempData["mensaje"] = $"Usuario {user.NickName} Agregado correctamente";
                return View("Login");
            }
            catch (Exception ex)
            {
                TempData["error"] = $"{ex.Message}";
                return View("VistaAgregarUsuario");
                
            }
        }
        //------------------------------------------------
        
    }
}