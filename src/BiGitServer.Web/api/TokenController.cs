using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BiGitServer.Web.api
{
    public class UserModel
    {
        public int id { get; set; }
        public string username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string token { get; set; }
        public double expireTime { get; set; }
        public string email { get; set; }
    }
    public class TokenController : ApiController
    {
        private double MilliTimeStamp(DateTime theDate)
        {
            DateTime d1 = new DateTime(1970, 1, 1);
            DateTime d2 = theDate.ToUniversalTime();
            TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);

            return ts.TotalMilliseconds;
        }
        // GET api/<controller>
        [AllowAnonymous]
        public UserModel Get(string username, string password)
        {
            if (CheckUser(username, password))
            {
                double expireTime = MilliTimeStamp( DateTime.Now.AddMinutes(JwtManager.ExpireMinutes));
                return new UserModel
                {
                    id = 1,
                    firstName = "fatih",
                    lastName = "gökçe",
                    token = JwtManager.GenerateToken(username),
                    username = username,
                    email=username,
                    expireTime= expireTime
                };
                   
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }
        //[AllowAnonymous]
        //[HttpGet]
        
        //[Route("~/{project}.git")]
        //public string Repo(string project)
        //{
        //    return project;
        //}
        public bool CheckUser(string username, string password)
        {
            // should check in the database
            return true;
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