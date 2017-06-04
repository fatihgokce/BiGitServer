using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace BiGitServer.Web2.jwt
{
    public class JwtManager
    {
        public const int ExpireMinutes = 2;
        public static string GenerateToken(string username, int expireMinutes = ExpireMinutes)
        {
             var now = DateTime.UtcNow;
            var handler = new JwtSecurityTokenHandler();

            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(username, "TokenAuth"),
                new[] { new Claim("ID", username) }
            );
            var tokenDesc = new SecurityTokenDescriptor
            {
                Issuer = TokenAuthOption.Issuer,
                Audience = TokenAuthOption.Audience,
                SigningCredentials = TokenAuthOption.SigningCredentials,
                Subject = identity,
                Expires = now.AddMinutes(expireMinutes)
            };
            var securityToken = handler.CreateToken(tokenDesc);
            return handler.WriteToken(securityToken);
        }
    }
}
