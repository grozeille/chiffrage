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
using Chiffrage.Mvc.Views;
using Chiffrage.Mvc.Controllers;
using Chiffrage.Mvc.Services;
using NHibernate;
using Chiffrage.Catalogs.Domain.Services;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Module
{
    public class CatalogModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<ICatalogRepository>(x => new CatalogRepository(x.ResolveNamed<ISessionFactory>("CatalogSessionFactory"))).SingleInstance();

            builder.RegisterAssemblyTypes(this.ThisAssembly)
                .Where(t => t.GetInterface(typeof(IView).Name) != null && !t.IsAbstract && t.IsPublic)
                .AsImplementedInterfaces()
                .SingleInstance()               
                .OnActivated(x =>
                {
                    x.Context.Resolve<IEventBroker>().Subscribe(x.Instance);
                });

            builder.RegisterAssemblyTypes(this.ThisAssembly)
                .Where(t => t.GetInterface(typeof(IController).Name) != null && !t.IsAbstract && t.IsPublic)
                .AsImplementedInterfaces()
                .SingleInstance()
                .OnActivated(x =>
                {
                    x.Context.Resolve<IEventBroker>().Subscribe(x.Instance);
                });

            builder.RegisterAssemblyTypes(typeof(CatalogService).Assembly)
                .Where(t => t.GetInterface(typeof(IService).Name) != null && !t.IsAbstract && t.IsPublic)
                .AsImplementedInterfaces()
                .SingleInstance()
                .OnActivated(x =>
                {
                    x.Context.Resolve<IEventBroker>().Subscribe(x.Instance);
                });

            base.Load(builder);
        }
    }
}
