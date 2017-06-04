using BiGitServer.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NHibernate;
using BiGitServer.Data.Models;
using System.IO;
using System.Web.Hosting;

namespace BiGitServer.Web.api
{
    [JwtAuthentication(Roles ="User")]
    public class ProjectController : BaseApi
    {
        // GET api/<controller>
        public IEnumerable<Project> Get()
        {
            return Session.QueryOver<Project>().List();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }
        //[HttpGet]
        //[AllowAnonymous]
        //public void ProjectGit()
        //{
        //    string gitAddress= string.Format("{0}://{1}{2}{3}/",
        //                               Request.Url.Scheme,
        //                               Request.Url.Host,
        //                               (Request.Url.IsDefaultPort ? "" : (":" + Request.Url.Port)),
        //                               Request.ApplicationPath == "/" ? "" : Request.ApplicationPath
        //                               );
        //}
        // POST api/<controller>
        public void Post([FromBody]Project value)
        {
            string directory = Path.Combine(HostingEnvironment.MapPath("~/App_Data"), "GitProjects");
            if (!Directory.Exists(directory)){
                Directory.CreateDirectory(directory);
            }
            directory = Path.Combine(directory, value.Name);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            LibGit2Sharp.Repository.Init(directory, true);
            Session.Save(value);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}