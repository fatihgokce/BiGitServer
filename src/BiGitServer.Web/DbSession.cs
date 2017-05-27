using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using BiGitServer.Data;
namespace BiGitServer.Web
{
    public sealed class DbSession
    {
        private const string contextKey = "MySession";    
      
        private static volatile DbSession instance;
        private static object syncRoot = new Object();

        private DbSession() { }

        public static DbSession Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new DbSession();
                    }
                }

                return instance;
            }
        }  
        public ISession GetSession
        {
            get
            {
                if (HttpContext.Current.Items[contextKey] == null)
                {
                    ISession session = NHibernateHelper.NSession;
                    HttpContext.Current.Items.Add(contextKey, session);
                }
                return (ISession)HttpContext.Current.Items[contextKey];

            }

        }

    
    }
}