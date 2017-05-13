using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BiGitServer.Data;
using NHibernate;
namespace BiGitServer.Web.api
{
    public abstract class BaseApi : ApiController
    {
        private ISession session;
        private ITransaction tx;
        public  ISession Session
        {
            get
            {
                if (session == null)
                {
                    session = NHibernateHelper.NSession;
                    tx = session.BeginTransaction();
                }
                return session;
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                using (session)
                {
                    using (tx)
                    {
                        if (tx != null)
                        {
                            tx.Commit();
                        }
                    }
                }

            }
            base.Dispose(disposing);
        }
    }
}