using System;
using System.Net;
using System.Text;
using System.Web.Mvc;
using NHibernate;
using BiGitServer.Data.Models;
namespace BiGitServer.Web.Filters
{
    public class GitAuthorizeAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var httpContext = filterContext.HttpContext;
            string authHeader = httpContext.Request.Headers["Authorization"];
            var url = filterContext.HttpContext.Request.Path;
            string repo = url.Substring(1, url.IndexOf(".git")-1);
            if (string.IsNullOrEmpty(authHeader))
            {
                httpContext.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"BiGitServer Git\"");
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
                return;
            }
            else
            {
                //
                byte[] bytes = Convert.FromBase64String(authHeader.Replace("Basic ", String.Empty));
                string value = Encoding.ASCII.GetString(bytes);
                string[] emailPassword = value.Split(':');
                int rowCount= DbSession.Instance.GetSession.QueryOver<User>().Where(x => x.Email == emailPassword[0] && x.Password==emailPassword[1]).RowCount();
                if (rowCount <= 0)
                {
                    filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
                }
               
            }
           
           
        }
    }
}