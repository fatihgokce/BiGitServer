using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
namespace BiGitServer.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SupportedMediaTypes
               .Add(new MediaTypeHeaderValue("text/html"));
            // Web API configuration and services
            //config.Filters.Add(new AuthorizeAttribute());
            // Web API routes
            config.MapHttpAttributeRoutes();
            // Home Index page have ng-app
            //config.Routes.MapHttpRoute(
            //      name: "GitApi",
            //      routeTemplate: "{project}.git",
            //      defaults: new {controller="Token",action="Repo"  }
            //  );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
    
        }
    }
}