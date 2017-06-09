using BiGitServer.Data;
using BiGitServer.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiGitServer.Web.Middlewares
{
  
    public class GitAuthenticationMiddleware
    {
        private readonly RequestDelegate next;
        private BiGitContext session;
        public GitAuthenticationMiddleware(RequestDelegate next,BiGitContext context)
        {
            this.next = next;
            this.session = context;
        }
  
        public async Task Invoke(HttpContext context)
        {
            string authoriztionHeader = context.Request.Headers["Authorization"];

            if (authoriztionHeader != null && authoriztionHeader.StartsWith("Basic"))
            {
                var encodedUsernamePassword = authoriztionHeader.Substring("Basic ".Length).Trim();
                var encoding = Encoding.GetEncoding("iso-8859-1");
                var usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));
                var seperatorIndex = usernamePassword.IndexOf(':');
                var username = usernamePassword.Substring(0, seperatorIndex);
                var password = usernamePassword.Substring(seperatorIndex + 1);
    
                bool existInDb = session.Users.Where(x => x.Email == username && x.Password == password).Count() > 0;
                if (existInDb)
                {           
                   
                    await this.next.Invoke(context);
                }
                else
                {
                    context.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"BiGitServer Git\"");
                    context.Response.StatusCode = 401;
                }
            }
            else
            {
                context.Response.Headers.Add("WWW-Authenticate", "Basic realm=\"BiGitServer Git\"");
                context.Response.StatusCode = 401;
            }
        }
    }
    public class GitAuthenticationMiddlewarePipeline
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<GitAuthenticationMiddleware>();//UseMyCustomAuthentication();
        }
    }
    //public static class MyCustomAuthenticationMiddlewareExtensions
    //{
    //    public static IApplicationBuilder UseMyCustomAuthentication(this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<GitAuthenticationMiddleware>();
    //    }
    //}
}
