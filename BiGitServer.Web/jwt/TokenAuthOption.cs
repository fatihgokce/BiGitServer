using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Security.Claims;
namespace BiGitServer.Web.jwt
{
    public class TokenAuthOption
    {
        public const string Secret = "856FECBA3B06519C8DDDBC80BB080553"; // your symetric
        private static byte[] symmetricKey = Convert.FromBase64String(Secret);
        public static string Audience { get; } = "MyAudience";
        public static string Issuer { get; } = "MyIssuer";
       public static RsaSecurityKey Key { get; } = new RsaSecurityKey(RSA.Create());
        public static SigningCredentials SigningCredentials { get; } =new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature); // new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature);
        //new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        // SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
        public static TimeSpan ExpiresSpan { get; } = TimeSpan.FromMinutes(40);
        public static string TokenType { get; } = "Bearer";
    }
    public class RSAKeyHelper
    {
        public static RSAParameters GenerateKey()
        {
            using (var key = new RSACryptoServiceProvider(2048))
            {
                return key.ExportParameters(true);
            }
        }
    }
}
