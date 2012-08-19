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

namespace Chiffrage.Ioc
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
            if (Chiffrage.Properties.Settings.Default.DealsRecentPath != null && Chiffrage.Properties.Settings.Default.DealsRecentPath.Count > 0)
            {
                file = Chiffrage.Properties.Settings.Default.DealsRecentPath[Chiffrage.Properties.Settings.Default.DealsRecentPath.Count - 1];
            }

            var dealConfiguration = new Configuration()
            .Proxy(p => p.ProxyFactoryFactory<NHibernate.Bytecode.DefaultProxyFactoryFactory>())
            .DataBaseIntegration(d =>
            {
                d.ConnectionString = string.Format("Data Source={0};Version=3;", file);
                d.Dialect<SQLiteDialect>();
                d.SchemaAction = SchemaAutoAction.Update;
            });
            var dealMapper = new ModelMapper();

            dealMapper.AddMappings(typeof(DealRepository).Assembly.GetTypes());

            HbmMapping dealMapping = dealMapper.CompileMappingForAllExplicitlyAddedEntities();
            dealConfiguration.AddMapping(dealMapping);

            return dealConfiguration.BuildSessionFactory();
        }

        private ISessionFactory BuildCatalogSessionFactory()
        {
            var catalogPath = Chiffrage.Properties.Settings.Default.CatalogPath;
            if (string.IsNullOrEmpty(catalogPath))
            {
                catalogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "catalog.cat");
            }

            var catalogConfiguration = new Configuration()
            .Proxy(p => p.ProxyFactoryFactory<NHibernate.Bytecode.DefaultProxyFactoryFactory>())
            .DataBaseIntegration(new Action<NHibernate.Cfg.Loquacious.IDbIntegrationConfigurationProperties>((d) =>
            {
                d.ConnectionString = string.Format("Data Source={0};Version=3;", catalogPath);
                d.Dialect<SQLiteDialect>();
                d.SchemaAction = SchemaAutoAction.Update;
            }));
            var catalogMapper = new ModelMapper();
            catalogMapper.AddMappings(typeof(CatalogRepository).Assembly.GetTypes());
            HbmMapping catalogMapping = catalogMapper.CompileMappingForAllExplicitlyAddedEntities();
            catalogConfiguration.AddMapping(catalogMapping);

            return catalogConfiguration.BuildSessionFactory();
        }
    }
}
