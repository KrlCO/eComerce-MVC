using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacionAdmin.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        public ActionResult Reestablecer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string correo, string clave)
        {
            Usuario oUser = new Usuario();
            oUser = new CN_Usuario().Listar().Where(u => u.Correo == correo && u.Clave == CN_Recursos.ConvertToSha256(clave)).FirstOrDefault();

            if (oUser == null)
            {
                ViewBag.Error = "Correo o Password incorrectos";
                return View();

            }
            else
            {
                ViewBag.Error = null;
                return RedirectToAction("Index", "Home");
            }

            return View();
        }




    }
}