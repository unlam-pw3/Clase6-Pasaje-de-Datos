using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clase6_Pasaje_de_datos.Helpers
{
    public class SessionHelper
    {
        public static string Mensaje4 
        { 
            get
            {
                return HttpContext.Current.Session["Mensaje4"] as string;
            }
            set
            {
                HttpContext.Current.Session["Mensaje4"] = value;
            }
        }

        public static DateTime FechaCreacionSession
        {
            get
            {
                return (DateTime) HttpContext.Current.Session["FechaCreacionSession"];
            }
            set
            {
                HttpContext.Current.Session["FechaCreacionSession"] = value;
            }
        }
    }
}