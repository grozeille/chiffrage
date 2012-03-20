using Chiffrage.Projects.Dal.Repositories;
using Chiffrage.Properties;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate;
using Chiffrage.Projects.Dal.Mappings;
using Strongshell.Recoil.Core.Composition;

namespace Chiffrage.Ioc
{
    public class DealContainer : WiringContainer
    {
        public override void SetupContainer()
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

            var dealSessionFactory = dealConfiguration.BuildSessionFactory();

            Define(() => new DealRepository(dealSessionFactory))
                .AsSingleton();

            Define(() => new ProjectRepository(dealSessionFactory))
                .AsSingleton();
        }
    }
}