using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiGitServer.Data.Mapping;
using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.Reflection;

namespace BiGitServer.Data
{
    public  class NHibernateHelper
    {        
        private static ISessionFactory sessionFactory;
        public static ISession NSession
        {
            get { return SessionFactory.OpenSession(); }
        }
        public static ISessionFactory SessionFactory
        {
            get { return sessionFactory ?? (sessionFactory = CreateSessionFactory()); }
        }

        public NHibernateHelper()
        {

        }

        private static ISessionFactory CreateSessionFactory()
        {
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["BiGitServerDb"].ConnectionString;
            return Fluently.Configure()
                   .Database(SQLiteConfiguration.Standard.ConnectionString(cs))

                   .Mappings(m=>m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                   //.ExposeConfiguration(BuildSchema)
                   
                   .BuildSessionFactory();
        }
    }
}
