using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using System.Data.SQLite;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate.Tool.hbm2ddl;

namespace WebApplicationNHibernate.Data
{
    public class NHibernateHelper : INHibernateHelper
    {
        private readonly string _connectionString;
        private readonly object _lockObject = new object();
        private ISessionFactory _sessionFactory;

        public NHibernateHelper(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Sqlite");
        }

        private ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    CreateSessionFactory();
                }

                return _sessionFactory;
            }
        }

        public ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private void CreateSessionFactory()
        {
            lock (_lockObject)
            {
                var fluentConfiguration = Fluently.Configure()
                    .Database(SQLiteConfiguration.Standard.ConnectionString(_connectionString))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<BlogMap>())
                    .BuildConfiguration();

                var exporter = new SchemaExport(fluentConfiguration);
                exporter.Execute(true, true, false);

                _sessionFactory = fluentConfiguration.BuildSessionFactory();
            }
        }
    }
}
