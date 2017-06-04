using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BiGitServer.Data2;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using BiGitServer.Web2.Middlewares;

namespace BiGitServer.Web2.Controllers
{   
    public abstract  class BaseApi : Controller
    {
        
        public override void OnActionExecuting(ActionExecutingContext context)
        {
           
            base.OnActionExecuting(context);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //if (session != null)
                //{
                //    session.Dispose();
                //}

            }
            base.Dispose(disposing);
        }
    }
}