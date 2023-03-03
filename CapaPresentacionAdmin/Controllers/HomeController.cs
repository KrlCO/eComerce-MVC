using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Usuarios()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarUsuarios()
        {
            List<Usuario> olista = new List<Usuario>();

            olista = new CN_Usuario().Listar();

            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult RegistrarUsuario(Usuario obj)
        {

            object result;
            string mensaje = string.Empty;

            if (obj.IdUsuario == 0)
            {
                result = new CN_Usuario().Registrar(obj, out mensaje);
            }
            else
            {
                result = new CN_Usuario().Editar(obj, out mensaje);
            }

            return Json(new { resultado = result, mensaje = mensaje}, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult EliminarUsuario(int id)
        {

            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Usuario().Eliminar(id, out mensaje);

            return Json(new {resultado = respuesta, mensaje = mensaje}, JsonRequestBehavior.AllowGet);

        }
    }
}