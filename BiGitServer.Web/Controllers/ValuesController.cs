using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BiGitServer.Data;
using Microsoft.EntityFrameworkCore;

namespace BiGitServer.Web.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : BaseApi
    {
        private BiGitContext context;

        public ValuesController(BiGitContext context)
        {
            this.context = context;
        }
        public static Guid NewGuid()
        {
            var guidBinary = new byte[16];
            Array.Copy(Guid.NewGuid().ToByteArray(), 0, guidBinary, 0, 8);
            Array.Copy(BitConverter.GetBytes(DateTime.Now.Ticks), 0, guidBinary, 8, 8);
            return new Guid(guidBinary);
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            // var list = context.Users.ToList();
            Role role1 = context.Roles.Include(c => c.Users).FirstOrDefault();
            
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
