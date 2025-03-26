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
    public class ContactoController : Controller
    {
        NegocioContacto neg = new NegocioContacto();
        NegocioMediosContacto negMedio = new NegocioMediosContacto();
        NegocioIntermedio negIntermedio = new NegocioIntermedio();

        // GET: Contacto
        public ActionResult Index()
        {
            try
            {
                //Obtener los datos de la session usuario y hacer un casteo para convertilo al tipo correcto
                Usuario usu = (Usuario)Session["Usuario"];
                ViewBag.FotoUsuario = usu.Foto;
                List<Contacto> contactos = neg.ObtenerTodos(usu);
                //Mostrar la lista de contactos
                return View(contactos);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Login", "Usuario");
            }
            
        }
        public ActionResult IrCrearContacto()
        {
            Usuario usu = (Usuario)Session["Usuario"];
            ViewBag.UsuarioId = usu.Id;
            return View("VistaCreateContacto");
        }
        public ActionResult AgregarContacto(Contacto con, HttpPostedFileBase FileFoto)
        {
            try
            {
                string rutaArchivo = Path.Combine(Server.MapPath("~/FotosContactos"), FileFoto.FileName);
                FileFoto.SaveAs(rutaArchivo);
                con.Foto = FileFoto.FileName;
                neg.AgregarContacto(con);
                //TempData["mensaje"] = $"Contacto {con.Nombre} Agregado correctamente";
                Usuario usu = (Usuario)Session["Usuario"];
                ViewBag.contactoId = con.Id;
                ViewBag.CatalogoMediosContacto = negMedio.ObtenerTodosMedios();
                ViewBag.MediosCreados = negIntermedio.ObtenerTodosIntermedios(con);
                return View("VistaDatosContacto");
            }
            catch(Exception ex)
            {
                TempData["error"] = $"{ex.Message}";
                return View("IrCrearContacto");
            }
        }
        public ActionResult AgregarMedio(Intermedio intermedio)
        {
            try
            {
                negIntermedio.AgregarIntermedio(intermedio);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = $"{ex.Message}";
                return View("VistaDatosContacto");
            }
        }
    }
}