using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace LO54_Projet
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code qui s’exécute au démarrage de l’application
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            string currentFile = HttpContext.Current.Request.Path;

            if (!currentFile.EndsWith("Login") && !currentFile.EndsWith("Login.aspx") 
                && !currentFile.EndsWith("Register") && !currentFile.EndsWith("Register.aspx"))
            {

                if (Context.User == null)
                {
                    Response.Redirect("/Account/Login.aspx", true);
                    Response.End();
                    return;
                }
            }
        }
    }
}