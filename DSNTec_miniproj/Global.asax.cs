using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DSNTec_miniproj
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private void Application_Error(Object sender, EventArgs e)
        {
            if (HttpContext.Current == null)
                return;

            HttpContext context = HttpContext.Current;
            Exception exception = context.Server.GetLastError();

            string errorInfo =
                "<br>Offending URL: " + context.Request.Url.ToString() +
                "<br>Source: " + exception.Source +
                "<br>Message: " + exception.Message +
                "<br>Stack trace: " + exception.StackTrace;

            context.Response.Write(errorInfo);
            context.Server.ClearError();
        }
    }
}
