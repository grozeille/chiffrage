using Chiffrage.Catalogs.Dal.Repositories;
using Chiffrage.Properties;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.ByteCode.Spring;
using Strongshell.Recoil.Core.Composition;
using System;
using System.IO;

namespace Chiffrage.Ioc
{
    public class CatalogContainer : WiringContainer
    {
        public override void SetupContainer()
        {
            var catalogPath = Settings.Default.CatalogPath;
            if (string.IsNullOrEmpty(catalogPath))
            {
                catalogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "catalog.cat");
            }

            var configurationCatalog = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                              .UsingFile(catalogPath)
                              .ProxyFactoryFactory(typeof (ProxyFactoryFactory)))
                .Mappings(m => m.FluentMappings.AddFromAssembly(typeof (CatalogRepository).Assembly))
                .BuildConfiguration();

            configurationCatalog.Properties["hbm2ddl.auto"] = "update";

            var sessionFactory = configurationCatalog.BuildSessionFactory();

            Define(() => new CatalogRepository(sessionFactory))
                .AsSingleton();
        }
    }
}