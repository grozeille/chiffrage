using System;
using System.IO;
using Chiffrage.Catalogs.Dal.Repositories;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using Strongshell.Recoil.Core.Composition;

namespace Chiffrage.Ioc
{
    public class CatalogContainer : WiringContainer
    {
        public override void SetupContainer()
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
            
            Define(() => new CatalogRepository(catalogSessionFactory))
                .AsSingleton();
        }
    }
}