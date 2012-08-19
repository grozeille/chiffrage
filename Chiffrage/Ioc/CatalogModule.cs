using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using System.IO;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using Chiffrage.Catalogs.Dal.Repositories;
using NHibernate.Cfg.MappingSchema;
using Chiffrage.Catalogs.Domain.Repositories;

namespace Chiffrage.Ioc
{
    public class CatalogModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var catalogPath = Chiffrage.Properties.Settings.Default.CatalogPath;
            if (string.IsNullOrEmpty(catalogPath))
            {
                catalogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "catalog.cat");
            }

            var catalogConfiguration = new Configuration()
            .Proxy(p => p.ProxyFactoryFactory<NHibernate.Bytecode.DefaultProxyFactoryFactory>())
            .DataBaseIntegration(d =>
            {
                d.ConnectionString = string.Format("Data Source={0};Version=3;", catalogPath);
                d.Dialect<SQLiteDialect>();
                d.SchemaAction = SchemaAutoAction.Update;
            });
            var catalogMapper = new ModelMapper();
            catalogMapper.AddMappings(typeof(CatalogRepository).Assembly.GetTypes());
            HbmMapping catalogMapping = catalogMapper.CompileMappingForAllExplicitlyAddedEntities();
            catalogConfiguration.AddMapping(catalogMapping);

            var catalogSessionFactory = catalogConfiguration.BuildSessionFactory();

            builder.Register<ICatalogRepository>(x => new CatalogRepository(catalogSessionFactory)).SingleInstance();

            base.Load(builder);
        }
    }
}
