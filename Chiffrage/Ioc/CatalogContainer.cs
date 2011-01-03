using Chiffrage.Catalogs.Dal.Repositories;
using Chiffrage.Properties;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.ByteCode.Spring;
using Strongshell.Recoil.Core.Composition;

namespace Chiffrage.Ioc
{
    public class CatalogContainer : WiringContainer
    {
        public override void SetupContainer()
        {
            var configurationCatalog = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                              .UsingFile(Settings.Default.CatalogPath)
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