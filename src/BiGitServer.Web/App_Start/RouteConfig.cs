using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BiGitServer.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            // dist / index.html
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("GitRepo",
                        "{project}.git/{*verb}",
                        new { controller = "Git", action = "Repo" });

          //  routes.MapRoute(
          //name: "Default",
          //url: "{controller}/{action}/{id}",
          //defaults: new { controller = "Home", action = "FakeData", id = UrlParameter.Optional }      );

           
        }
    }
}
