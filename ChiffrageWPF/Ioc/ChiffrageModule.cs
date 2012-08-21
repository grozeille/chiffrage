using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Views;
using Chiffrage.Mvc.Controllers;
using Chiffrage.Mvc.Services;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate;
using NHibernate.Mapping.ByCode;
using Chiffrage.Projects.Dal.Repositories;
using NHibernate.Cfg.MappingSchema;
using System.IO;
using Chiffrage.Catalogs.Dal.Repositories;

namespace ChiffrageWPF.Ioc
{
    public class ChiffrageModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
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

            builder.RegisterAssemblyTypes(this.ThisAssembly)
                .Where(t => t.GetInterface(typeof(IService).Name) != null && !t.IsAbstract && t.IsPublic)
                .AsImplementedInterfaces()
                .SingleInstance()
                .OnActivated(x =>
                {
                    x.Context.Resolve<IEventBroker>().Subscribe(x.Instance);
                });

            // the eventBroker
            builder.RegisterType<EventBroker>()
                .As<IEventBroker>()
                .SingleInstance()
                .OnActivated(x => x.Instance.Start());

            
                //.OnActivated(x =>
                //{
                //    x.Instance.Subscribers = x.Context.Resolve<IEnumerable<Object>>().ToArray();
                //});


            // force creation of all services/view/controllers
            builder.RegisterType<ModuleBootstrap>()
                .As<IStartable>()
                .PropertiesAutowired(PropertyWiringFlags.Default)
                .SingleInstance();

            base.Load(builder);
        }
    }
}
