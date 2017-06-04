
using BiGitServer.Web2.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BiGitServer.Web2.api
{
    public class ValuesController : BaseApi
    {
        // GET api/<controller>
        //[JwtAuthentication]
        public List<UserModel> Get()
        {
            //BiGitServer.Data.Models.User user = Session.QueryOver<User>().SingleOrDefault();
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