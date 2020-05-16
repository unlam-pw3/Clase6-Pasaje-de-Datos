using Clase6_Pasaje_de_datos.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Clase6_Pasaje_de_datos
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        void Session_Start(object sender, EventArgs e)
        {
            // your code here, it will be executed upon session start
            SessionHelper.FechaCreacionSession = DateTime.Now;
        }
    }
}
