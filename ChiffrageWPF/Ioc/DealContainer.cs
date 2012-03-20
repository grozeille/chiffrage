using Chiffrage.Projects.Dal.Repositories;
using ChiffrageWPF.Properties;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.ByteCode.Spring;
using Strongshell.Recoil.Core.Composition;

namespace Chiffrage.Ioc
{
    public class DealContainer : WiringContainer
    {
        public override void SetupContainer()
        {
            var file = "deal.cat";
            if (Settings.Default.DealsRecentPath != null && Settings.Default.DealsRecentPath.Count > 0)
            {
                file = Settings.Default.DealsRecentPath[Settings.Default.DealsRecentPath.Count - 1];
            }

            var configurationDeals = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                              .UsingFile(file)
                              .ProxyFactoryFactory(typeof (ProxyFactoryFactory)))
                .Mappings(m => m.FluentMappings.AddFromAssembly(typeof (DealRepository).Assembly))
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