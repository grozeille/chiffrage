using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using Chiffrage.Projects.Dal.Repositories;
using NHibernate.Cfg.MappingSchema;
using System.IO;
using Chiffrage.Catalogs.Dal.Repositories;
using Chiffrage.App;
using NHibernate.Context;

namespace Chiffrage.App.Ioc
{
    public class NHibernateModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance<ISessionFactory>(this.BuildCatalogSessionFactory()).Named<ISessionFactory>("CatalogSessionFactory");

            builder.RegisterInstance<ISessionFactory>(this.BuildProjectsSessionFactory()).Named<ISessionFactory>("ProjectSessionFactory");

            base.Load(builder);
        }

        private ISessionFactory BuildProjectsSessionFactory()
        {
            // register nhibernate
            var file = "deal.cat";
            if (Chiffrage.App.Properties.Settings.Default.DealsRecentPath != null && Chiffrage.App.Properties.Settings.Default.DealsRecentPath.Count > 0)
            {
                file = Chiffrage.App.Properties.Settings.Default.DealsRecentPath[Chiffrage.App.Properties.Settings.Default.DealsRecentPath.Count - 1];
            }

            var dealConfiguration = new Configuration()
            .Proxy(p => p.ProxyFactoryFactory<NHibernate.Bytecode.DefaultProxyFactoryFactory>())
            .CurrentSessionContext<CatalogSessionContext>()
            .DataBaseIntegration(d =>
            {
                d.ConnectionReleaseMode = ConnectionReleaseMode.OnClose;
                //d.LogFormattedSql = true;
                d.ConnectionString = string.Format("Data Source={0};Version=3;", file);
                d.Dialect<SQLiteDialect>();
                if(IsRunningOnMono())
                {
                    d.Driver<MonoSQLiteDriver>();
                }
                d.SchemaAction = SchemaAutoAction.Update;
            });
            var dealMapper = new ModelMapper();

            dealMapper.AddMappings(typeof(DealRepository).Assembly.GetTypes());

            HbmMapping dealMapping = dealMapper.CompileMappingForAllExplicitlyAddedEntities();
            dealConfiguration.AddMapping(dealMapping);

            var factory = dealConfiguration.BuildSessionFactory();

            ProjectSessionContext.Bind(factory.OpenSession());

            return factory;
        }

        private ISessionFactory BuildCatalogSessionFactory()
        {
            var catalogPath = Chiffrage.App.Properties.Settings.Default.CatalogPath;
            if (string.IsNullOrEmpty(catalogPath))
            {
                catalogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "catalog.cat");
            }

            var catalogConfiguration = new Configuration()
            .Proxy(p => p.ProxyFactoryFactory<NHibernate.Bytecode.DefaultProxyFactoryFactory>())
            .CurrentSessionContext<ProjectSessionContext>()
            .DataBaseIntegration(new Action<NHibernate.Cfg.Loquacious.IDbIntegrationConfigurationProperties>((d) =>
            {
                d.ConnectionReleaseMode = ConnectionReleaseMode.OnClose;
                //d.LogFormattedSql = true;
                d.ConnectionString = string.Format("Data Source={0};Version=3;", catalogPath);
                d.Dialect<SQLiteDialect>();
                if(IsRunningOnMono())
                {
                    d.Driver<MonoSQLiteDriver>();
                }
                d.SchemaAction = SchemaAutoAction.Update;
            }));
            var catalogMapper = new ModelMapper();
            catalogMapper.AddMappings(typeof(CatalogRepository).Assembly.GetTypes());
            HbmMapping catalogMapping = catalogMapper.CompileMappingForAllExplicitlyAddedEntities();
            catalogConfiguration.AddMapping(catalogMapping);

            var factory = catalogConfiguration.BuildSessionFactory();

            CatalogSessionContext.Bind(factory.OpenSession());

            return factory;
        }

        public static bool IsRunningOnMono ()
        {
            return Type.GetType ("Mono.Runtime") != null;
        }
    }
}
