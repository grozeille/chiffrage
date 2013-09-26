using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Chiffrage.EventStore.Repositories;
using Chiffrage.Mvc.Events;
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

            builder.RegisterInstance<ISessionFactory>(this.BuildEventSessionFactory()).Named<ISessionFactory>("EventSessionFactory");

            builder.Register<CatalogSessionManagerService>(x => new CatalogSessionManagerService(x.ResolveNamed<ISessionFactory>("CatalogSessionFactory"), x.Resolve<IEventBroker>())).SingleInstance();
            builder.Register<ProjectSessionManagerService>(x => new ProjectSessionManagerService(x.ResolveNamed<ISessionFactory>("ProjectSessionFactory"), x.Resolve<IEventBroker>())).SingleInstance();

            base.Load(builder);
        }

        private ISessionFactory BuildProjectsSessionFactory()
        {
            var oldPath = "deal.cat";
            var file = "data\\deal.sqlite";
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }

            // migration des vieux fichiers
            if (!File.Exists(file) && File.Exists(oldPath))
            {
                File.Copy(oldPath, file);
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
            
            return factory;
        }

        private ISessionFactory BuildCatalogSessionFactory()
        {
            var oldPath = "catalog.cat";
            var file = "data\\catalog.sqlite";
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }

            // migration des vieux fichiers
            if (!File.Exists(file) && File.Exists(oldPath))
            {
                File.Copy(oldPath, file);
            }

            var catalogConfiguration = new Configuration()
            .Proxy(p => p.ProxyFactoryFactory<NHibernate.Bytecode.DefaultProxyFactoryFactory>())
            .CurrentSessionContext<ProjectSessionContext>()
            .DataBaseIntegration(new Action<NHibernate.Cfg.Loquacious.IDbIntegrationConfigurationProperties>((d) =>
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
            }));
            var catalogMapper = new ModelMapper();
            catalogMapper.AddMappings(typeof(CatalogRepository).Assembly.GetTypes());
            HbmMapping catalogMapping = catalogMapper.CompileMappingForAllExplicitlyAddedEntities();
            catalogConfiguration.AddMapping(catalogMapping);

            var factory = catalogConfiguration.BuildSessionFactory();
            
            return factory;
        }

        private ISessionFactory BuildEventSessionFactory()
        {
            var file = "data\\events.sqlite";
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }

            var configuration = new Configuration()
            .Proxy(p => p.ProxyFactoryFactory<NHibernate.Bytecode.DefaultProxyFactoryFactory>())
            .CurrentSessionContext<EventStoreSessionContext>()
            .DataBaseIntegration(d =>
            {
                d.ConnectionReleaseMode = ConnectionReleaseMode.OnClose;
                //d.LogFormattedSql = true;
                d.ConnectionString = string.Format("Data Source={0};Version=3;", file);
                d.Dialect<SQLiteDialect>();
                if (IsRunningOnMono())
                {
                    d.Driver<MonoSQLiteDriver>();
                }
                d.SchemaAction = SchemaAutoAction.Update;
            });
            var mapper = new ModelMapper();

            mapper.AddMappings(typeof(EventRepository).Assembly.GetTypes());

            HbmMapping mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            configuration.AddMapping(mapping);

            var factory = configuration.BuildSessionFactory();

            return factory;
        }

        public static bool IsRunningOnMono ()
        {
            return Type.GetType ("Mono.Runtime") != null;
        }
    }
}
