using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Dal.Repositories;
using Chiffrage.Projects.Dal.Repositories;
using Chiffrage.Properties;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Strongshell.Recoil.Core.Composition;
using Spring.Objects.Factory.Config;

namespace Chiffrage
{
    public class CatalogContainer : WiringContainer
    {
        public override void SetupContainer()
        {
            var configurationCatalog = Fluently.Configure()
                    .Database(SQLiteConfiguration.Standard
                        .UsingFile(Settings.Default.CatalogPath)
                        .ProxyFactoryFactory(typeof(NHibernate.ByteCode.Spring.ProxyFactoryFactory)))
                    .Mappings(m => m.FluentMappings.AddFromAssembly(typeof(CatalogRepository).Assembly))
                    .BuildConfiguration();

            configurationCatalog.Properties["hbm2ddl.auto"] = "update";

            var sessionFactory = configurationCatalog.BuildSessionFactory();

            Define(() => new CatalogRepository(sessionFactory))
                .AsSingleton();
        }
    }
}
