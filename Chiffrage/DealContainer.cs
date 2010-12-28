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
    public class DealContainer : WiringContainer
    {
        public override void SetupContainer()
        {
            var configurationDeals = Fluently.Configure()
                    .Database(SQLiteConfiguration.Standard
                        .UsingFile(Settings.Default.DealsRecentPath[Settings.Default.DealsRecentPath.Count - 1])
                        .ProxyFactoryFactory(typeof(NHibernate.ByteCode.Spring.ProxyFactoryFactory)))
                    .Mappings(m => m.FluentMappings.AddFromAssembly(typeof(DealRepository).Assembly))
                    .BuildConfiguration();

            configurationDeals.Properties["hbm2ddl.auto"] = "update";

            var sessionFactory = configurationDeals.BuildSessionFactory();

            Define(() => new DealRepository(sessionFactory))
                .AsSingleton();

            Define(() => new ProjectRepository(sessionFactory))
                .AsSingleton();
        }
    }
}
