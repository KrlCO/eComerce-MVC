using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocio;
using Newtonsoft.Json;

namespace CapaPresentacionAdmin.Controllers
{
    public class MantenedorController : Controller
    {
        // GET: Mantenedor
        public ActionResult Categoria()
        {
            return View();
        }
        public ActionResult Marca()
        {
            return View();
        }
        public ActionResult Producto()
        {
            return View();
        }

        //--Categoria--\\

        [HttpGet]
        public JsonResult ListarCategorias()
        {
            List<Categoria> olist = new List<Categoria>();
            olist = new CN_Categoria().Listar();
            return Json(new {data = olist}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RegistrarCategoria(Categoria cat)
        {
            object resultado;
            string mensaje = string.Empty;

            if (cat.IdCategoria == 0)
            {
                resultado = new CN_Categoria().Registrar(cat, out mensaje);

            }
            else
            {
                resultado = new CN_Categoria().Editar(cat, out mensaje);
            }
            return Json(new {resultado = resultado, mensaje = mensaje}, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult EliminarCategoria(int id)
        {
            bool rpta = false;
            string mensaje = string.Empty;

            rpta = new CN_Categoria().Eliminar(id, out mensaje);

            return Json(new {result = rpta, mensaje = mensaje}, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult ListarMarca()
        {
            List<Marca> oLista = new List<Marca>();
            oLista = new CN_Marca().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RegistrarMarca(Marca obj)
        {
            object result;
            string mensaje = string.Empty;

            if(obj.IdMarca == 0)
            {
                result = new CN_Marca().Registrar(obj, out mensaje);
            }
            else
            {
                result = new CN_Marca().Editar(obj, out mensaje);
            }
            return Json(new {result = result, mensaje = mensaje}, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult EliminarMarca(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Marca().Eliminar(id, out mensaje);  

            return Json(new {resultado = respuesta, mensaje = mensaje}, JsonRequestBehavior.AllowGet);  
        }


    }
}