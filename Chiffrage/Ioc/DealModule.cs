using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using Chiffrage.Projects.Dal.Repositories;
using NHibernate.Cfg.MappingSchema;
using Chiffrage.Projects.Domain.Repositories;

namespace Chiffrage.Ioc
{
    public class DealModule : Module
    {
        protected override void Load(ContainerBuilder builder)
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

            builder.Register<IDealRepository>(x => new DealRepository(dealSessionFactory)).SingleInstance();
            builder.Register<IProjectRepository>(x => new ProjectRepository(dealSessionFactory)).SingleInstance();

            base.Load(builder);
        }
    }
}
