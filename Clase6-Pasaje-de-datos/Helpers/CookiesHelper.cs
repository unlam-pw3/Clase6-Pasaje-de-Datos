using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clase6_Pasaje_de_datos.Helpers
{
    public class CookiesHelper
    {
        /// <summary>
        /// setea la cookie Mensaje con una expiracion de 1 minuto
        /// </summary>
        public static string Mensaje
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["Mensaje"] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Request.Cookies["Mensaje"].Value;
                }
            }
            set
            {
                if (HttpContext.Current.Request.Cookies["Mensaje"] != null)
                {
                    HttpContext.Current.Response.Cookies.Remove("Mensaje");
                }

                var cookie = new HttpCookie("Mensaje");
                //Expira en un minuto
                cookie.Expires = DateTime.Now.AddMinutes(1);
                cookie.Value = value;
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
    }
}