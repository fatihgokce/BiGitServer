using System;
using System.Collections.Generic;
using System.Linq;

using BiGitServer.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BiGitServer.Web.Controllers
{
    //[JwtAuthentication]
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    public class UserController : BaseApi
    {
        private BiGitContext session;
     
        public UserController(BiGitContext context)
        {         
            session = context;
        }
        // GET api/<controller>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return session.Users.ToList();//Session.QueryOver<User>().List();
        }
        
        [HttpGet]
        [Route("api/user/ExistUser")]
        public bool ExistUser(string columnName,string value)
        {
            if (columnName == "email")
            {
                return true;//Session.QueryOver<User>().Where(x => x.Email == value).RowCount() > 0;
            }
            else
            {
                return false;//Session.QueryOver<User>().Where(x => x.Email == value).RowCount() > 0;
            }
        }
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]User value)
        {         
            value.Id = Guid.NewGuid().ToString();
            session.Users.Add(value);
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