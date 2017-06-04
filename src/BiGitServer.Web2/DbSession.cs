using System;
using BiGitServer.Data2;
using Microsoft.AspNetCore.Http;

namespace BiGitServer.Web
{
    public sealed class DbSession
    {       
      
        private static  DbSession instance;     
        private DbSession() { }

        public static DbSession Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DbSession();
                }

                return instance;
            }
         
        }  
        public BiGitContext Db
        {
            get;set;    
        }

    
    }
}