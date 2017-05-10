using BiGitServer.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BiGitServer.Web.api
{
    public class ValuesController : ApiController
    {
        // GET api/<controller>
        [JwtAuthentication]
        public List<UserModel> Get()
        {
            return new List<UserModel>
            {
                new UserModel{id=2,firstName="bir",lastName="bir s",username="gttr"},
                new UserModel{id=2,firstName="iki",lastName="iki s",username="iki um"},
                new UserModel{id=2,firstName="üç",lastName="üç s",username="üç un"}
            };
        }
        [Route("api/values/GetAllUsers")]
        [AllowAnonymous]
        [HttpGet]
        public List<UserModel> GetAllUsers()
        {
            return new List<UserModel>
            {
                new UserModel{id=2,firstName="bir",lastName="bir s",username="gttr"},
                new UserModel{id=2,firstName="iki",lastName="iki s",username="iki um"},
                new UserModel{id=2,firstName="üç",lastName="üç s",username="üç un"}
            };
        }
        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
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