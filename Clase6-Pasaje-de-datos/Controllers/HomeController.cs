using Clase6_Pasaje_de_datos.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clase6_Pasaje_de_datos.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Mensaje = "Hola clase ViewBag";
            ViewData["Mensaje"] = "Hola clase ViewData";
            TempData["Mensaje"] = "Hola clase TempData";

            return View();
        }

        [HttpPost]
        public ActionResult IndexPost(string mensaje)
        {
            ViewBag.Mensaje = "Hola clase ViewBag POST";
            ViewData["Mensaje"] = "Hola clase ViewData POST";
            
            //los valores en TempData duran un request extra
            TempData["Mensaje"] = "Hola clase TempData POST";

            SessionHelper.Mensaje4 = mensaje;

            HttpContext.Application["Mensaje"] = mensaje;

            //https://docs.microsoft.com/es-es/dotnet/api/system.web.httpapplicationstate.lock?redirectedfrom=MSDN&view=netframework-4.8#System_Web_HttpApplicationState_Lock
            //en caso querer que ciertas operaciones sobre objetos compartidos en application se debe usar lock y unlock para mejorar la eficiencia
            HttpContext.Application.Lock();
            if (HttpContext.Application["count"] == null)
                HttpContext.Application["count"] = 0;
            HttpContext.Application["count"] = Convert.ToInt32(HttpContext.Application["count"]) + 1;
            HttpContext.Application.UnLock();

            HttpContext.Cache["Mensaje"] = mensaje;
            HttpContext.Cache.Insert("MensajeDura20seg", mensaje, null, DateTime.Now.AddSeconds(20), new TimeSpan());

            CookiesHelper.Mensaje = mensaje;

            return RedirectToAction("ResumenPasajeDeDatos");
        }

        public ActionResult EjemploSession()
        {
            Session.Add("Mensaje", "Hola clase Session");
            Session["Mensaje2"] = "Hola clase Session2";

            return View();
        }

        [HttpPost]
        public ActionResult EjemploSession(string mensaje3)
        {
            Session["Mensaje3"] = mensaje3;
            SessionHelper.Mensaje4 = mensaje3;
            string mensajeLargo = $"{SessionHelper.Mensaje4} - {SessionHelper.Mensaje4} - {SessionHelper.Mensaje4}";

            return View();
        }


        public ActionResult ResumenPasajeDeDatos()
        {
            return View();
        }
    }
}