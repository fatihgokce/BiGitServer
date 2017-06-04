using BiGitServer.Web2.jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;

namespace BiGitServer.Web2.Controllers
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
    [Route("api/[controller]")]
    public class TokenController : BaseApi
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
        public IActionResult Get(string username, string password)
        {
            if (CheckUser(username, password))
            {
                double expireTime = MilliTimeStamp(DateTime.Now.AddMinutes(JwtManager.ExpireMinutes));
                var requestAt = DateTime.Now;
                var expiresIn = requestAt + TokenAuthOption.ExpiresSpan;
                var user= new UserModel
                {
                    id = 1,
                    firstName = "fatih",
                    lastName = "gökçe",
                    //token = JwtManager.GenerateToken(username),
                    username = username,
                    email = username,
                    expireTime = expireTime
                };
                var token =JwtManager.GenerateToken(username);
              
                return Json(new RequestResult
                {
                    State = RequestState.Success,
                    Data = new
                    {
                        requertAt = requestAt,
                        expiresIn = expireTime, //TokenAuthOption.ExpiresSpan.TotalMilliseconds,
                        tokeyType = TokenAuthOption.TokenType,
                        accessToken = token,
                        user=user
                    }
                });

            }
            else
            {
                return Json(new RequestResult
                {
                    State = RequestState.Failed,
                    Msg = "Username or password is invalid"
                });
            }
            //return null;
            //throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }
     
        private bool CheckUser(string username, string password)
        {
            // should check in the database
            return true;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}