using BiGitServer.Data;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using System.IO;
using LibGit2Sharp;
using Microsoft.AspNetCore.Authorization;

namespace BiGitServer.Web.Controllers
{
    [Authorize()]
    [Route("api/[controller]")] 
    public class ProjectController : Controller
    {
        private BiGitContext session;
        private IHostingEnvironment _env;
        public ProjectController(BiGitContext context, IHostingEnvironment env)
        {
            _env = env;
            session = context;
        }
        // GET api/<controller>
        [HttpGet]
        public List<Project> Get()
        {
            return session.Projects.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody]Project value)
        {
            string directory = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(),"App_Data"), "GitProjects");
            if (!Directory.Exists(directory)){
                Directory.CreateDirectory(directory);
            }
            directory = Path.Combine(directory, value.Name);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            LibGit2Sharp.Repository.Init(directory, true);
            session.Projects.Add(value);
            session.SaveChanges();
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