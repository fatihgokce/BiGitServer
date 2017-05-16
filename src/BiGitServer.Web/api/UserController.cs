﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NHibernate;
using BiGitServer.Data.Models;
using BiGitServer.Web.Filters;

namespace BiGitServer.Web.api
{
    [JwtAuthentication]
    public class UserController : BaseApi
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        [HttpGet]
        [Route("api/user/ExistUser")]
        public bool ExistUser(string columnName,string value)
        {
            if (columnName == "username")
            {
                return Session.QueryOver<User>().Where(x => x.Username == value).RowCount() > 0;
            }
            else
            {
                return Session.QueryOver<User>().Where(x => x.Email == value).RowCount() > 0;
            }
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