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
            if (Session["Usuario"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            try
            {
                //Obtener los datos de la session usuario y hacer un casteo para convertilo al tipo correcto
                Usuario usu = (Usuario)Session["Usuario"];
                ViewBag.FotoUsuario = usu.Foto;
                List<Contacto> contactos = neg.ObtenerTodos(usu);

                return View(contactos);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Login", "Usuario");
            }
        }
        public ActionResult VistaCrearContacto()
        {
            Usuario usu = (Usuario)Session["Usuario"];
            ViewBag.UsuarioId = usu.Id;
            return View("VistaAgregarContacto");
        }
        public ActionResult AgregarContactoTabla(Contacto con, HttpPostedFileBase FileFoto)
        {
            try
            {
                if (FileFoto == null)
                {
                    con.Foto = "default.png";
                }
                else
                {
                    string rutaArchivo = Path.Combine(Server.MapPath("~/FotosContactos"), FileFoto.FileName);
                    FileFoto.SaveAs(rutaArchivo);
                    con.Foto = FileFoto.FileName;
                }
                neg.AgregarContacto(con);

                return RedirectToAction("IrIntermedio", con);
            }
            catch (Exception ex)
            {
                TempData["error"] = $"{ex.Message}";
                return View("IrCrearContacto");
            }
        }
        public ActionResult IrIntermedio(Contacto con)
        {
            ViewBag.contactoId = con.Id;
            ViewBag.CatalogoMediosContacto = negMedio.ObtenerTodosMedios();
            ViewBag.ListaIntermedio = negIntermedio.ObtenerTodosIntermedios(con.Id);
            return View("VistaDatosContacto");
        }
        public ActionResult VistaActualizarContacto(int ID)
        {
            Contacto contacto = neg.ObtenerContacto(ID);
            return View("VistaEditarContacto", contacto);
        }
        public ActionResult EditarContacto(Contacto con, HttpPostedFileBase FileFoto)
        {
            try
            {
                if (FileFoto != null)
                {
                    string rutaArchivo = Path.Combine(Server.MapPath("~/FotosContactos"), FileFoto.FileName);
                    FileFoto.SaveAs(rutaArchivo);
                    con.Foto = FileFoto.FileName;
                }

                neg.ActualizarContacto(con);
                TempData["mensaje"] = $"Contacto {con.Nombre} Actualizado correctamente";

            }
            catch (Exception ex)
            {
                TempData["error"] = $"{ex.Message}";

            }
            return RedirectToAction("Index");
        }
        public ActionResult EliminarContacto(int ID)
        {
            try
            {
                neg.EliminarContacto(ID);
                TempData["mensaje"] = $"Contacto Eliminado correctamente";

            }
            catch (Exception ex)
            {
                TempData["error"] = $"{ex.Message}";

            }
            return RedirectToAction("Index");
        }
        //---------------------------------------------------------------------------------------------
        public ActionResult AgregarMedio(Intermedio intermedio)
        {
            try
            {
                Contacto con = neg.ObtenerContacto(intermedio.ContactoId);
                //intermedio.ContactoId = con.Id;
                negIntermedio.AgregarIntermedio(intermedio);
                TempData["mensaje"] = $"Medio {intermedio.informacion} Agregado correctamente";

                ViewBag.CatalogoMediosContacto = negMedio.ObtenerTodosMedios();
                ViewBag.ListaIntermedio = negIntermedio.ObtenerTodosIntermedios(intermedio.ContactoId);

                return RedirectToAction("IrIntermedio", con);
            }
            catch (Exception ex)
            {
                TempData["error"] = $"{ex.Message}";
                return View("VistaDatosContacto");
            }
        }
        public ActionResult VistaActualizarMedioContacto(int ID)
        {
            Contacto con = neg.ObtenerContacto(ID);
            ViewBag.contactoId = con.Id;
            ViewBag.CatalogoMediosContacto = negMedio.ObtenerTodosMedios();
            ViewBag.ListaIntermedio = negIntermedio.ObtenerTodosIntermedios(ID);

            TempData["mensaje"] = $"{con.Nombre}";
            return View("VistaDatosContacto");
        }
        public ActionResult IntermedioEliminar(int ID)
        {
            try
            {
                Intermedio intermedio = negIntermedio.ObtenerIntermedio(ID);
                Contacto con = neg.ObtenerContacto(intermedio.ContactoId);

                negIntermedio.EliminarIntermedio(ID);
                TempData["error"] = $"Medio {intermedio.informacion} Eliminado correctamente";

                ViewBag.CatalogoMediosContacto = negMedio.ObtenerTodosMedios();
                ViewBag.ListaIntermedio = negIntermedio.ObtenerTodosIntermedios(intermedio.ContactoId);
                return RedirectToAction("IrIntermedio", con);
            }
            catch (Exception ex)
            {
                TempData["error"] = $"{ex.Message}";
                return View("VistaDatosContacto");
            }
        }
        public ActionResult VistaIntermedioEditar(int ID)
        {
            Intermedio intermedio = negIntermedio.ObtenerIntermedio(ID);
            ViewBag.CatalogoMediosContacto = negMedio.ObtenerTodosMedios();
            return View("VistaEditarIntermedio", intermedio);
        }
        public ActionResult ActualizarIntermdeio(Intermedio intermedio)
        {
            negIntermedio.ActualiarIntermedio(intermedio);
            Contacto con = neg.ObtenerContacto(intermedio.ContactoId);
            return RedirectToAction("IrIntermedio", con);
        }
        public ActionResult BuscarNombre(string Buscador)
        {
            List<Contacto> lista = new List<Contacto>();
            Usuario usu = (Usuario)Session["Usuario"];
            if (string.IsNullOrEmpty(Buscador))
            {
                lista = neg.ObtenerTodos(usu);
            }
            else
            {
                lista = neg.BuscarContacto(Buscador);
            }
            return View("Index", lista);
        }
        //------------------------R-------------------------


        //public ActionResult Index()
        //{
        //    if (Session["usuario"] == null)
        //    {
        //        return RedirectToAction("Login", "Usuario");
        //    }


        //    //Mostrar una lista de contatos de un usuario

        //    Usuario usu = (Usuario)Session["usuario"];

        //    Negocio_Contactos negocio = new Negocio_Contactos();

        //    List<Contacto> lista = negocio.ObtenerContactos(usu.id);

        //    return View("Index", lista);
        //}

        //Agregar Contacto 

        public ActionResult AgregarContactoR(Contacto usu, HttpPostedFileBase FileFoto)
        {

            string rutaArchivo = Path.Combine(Server.MapPath("~/FotosContactos"), FileFoto.FileName);
            FileFoto.SaveAs(rutaArchivo);
            usu.Foto = FileFoto.FileName;

            ViewBag.UsuarioId = usu.UsuarioId;

            NegocioContacto negocio = new NegocioContacto();
            negocio.AgregarContacto(usu);

            ViewBag.contactoId = usu.Id;

            TempData["mensaje"] = $"Se agrego Contacto";

            NegocioMediosContacto negocioMc = new NegocioMediosContacto();
            List<MediosDeContacto> lista = negocioMc.ObtenerTodosMedios();
            ViewBag.catalogoMediosContacto = lista;

            return View("MediosContacto");


        }

        public ActionResult IrVistaAgregar()
        {
            Usuario usu = (Usuario)Session["usuario"];
            ViewBag.UsuarioId = usu.Id;

            return View("AgregarContacto");
        }

        public ActionResult AgregarMediodeContacto(Intermedio mc)
        {

            try
            {
                NegocioIntermedio negocio = new NegocioIntermedio();
                negocio.AgregarIntermedio(mc);

                NegocioMediosContacto negocioMc = new NegocioMediosContacto();
                List<MediosDeContacto> lista = negocioMc.ObtenerTodosMedios();
                ViewBag.catalogoMediosContacto = lista;

                return RedirectToAction("ObtenerMediodeContacto", new { id = mc.ContactoId });
            }
            catch (Exception ex)
            {

                TempData["Error"] = ex.Message;
                return View("MediosContacto");
            }

        }

        public ActionResult ObtenerMediodeContacto(int id)
        {
            NegocioMediosContacto negocioMc = new NegocioMediosContacto();
            List<MediosDeContacto> lista = negocioMc.ObtenerTodosMedios();
            ViewBag.catalogoMediosContacto = lista;

            NegocioIntermedio negocio = new NegocioIntermedio();
            List<Intermedio> lista1 = negocio.ObtenerTodosIntermedios(id);

            return View("MediosContacto", lista1);


        }


        //public ActionResult AgregarMedioContacto1(Intermedia mc)
        //{
        //    Negocio_Intermedia negocio = new Negocio_Intermedia();
        //    negocio.AgregarMediodeContacto(mc);
        //    return View("MediosContacto");

        //}




    }
}

