using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Views;
using Chiffrage.Mvc.Controllers;
using Chiffrage.Mvc.Services;

namespace Chiffrage.Ioc
{
    public class MvcModule : Module
    {
        private System.Reflection.Assembly[] assemblies;

        protected override void Load(ContainerBuilder builder)
        {
            // force load referenced assemblies
            this.assemblies = System.Reflection.Assembly.GetExecutingAssembly()
                .GetReferencedAssemblies()
                .Where(x => x.FullName.StartsWith("Chiffrage"))
                .Select(x => System.Reflection.Assembly.Load(x))
                .Union(new System.Reflection.Assembly[] { System.Reflection.Assembly.GetExecutingAssembly() })
                .ToArray();

            builder.RegisterAssemblyTypes(this.assemblies)
                .Where(t => t.GetInterface(typeof(IView).Name) != null && !t.IsAbstract && t.IsPublic)
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterAssemblyTypes(this.assemblies)
                .Where(t => t.GetInterface(typeof(IController).Name) != null && !t.IsAbstract && t.IsPublic)
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterAssemblyTypes(this.assemblies)
                .Where(t => t.GetInterface(typeof(IService).Name) != null && !t.IsAbstract && t.IsPublic)
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<EventBroker>()
                .As<IEventBroker>()
                .SingleInstance()
                .OnActivated(x =>
                {
                    x.Instance.Subscribers = x.Context.Resolve<IEnumerable<IEventHandler>>().ToArray();
                });

            base.Load(builder);
        }

        private IEnumerable<Type> GetViews()
        {

            return this.assemblies.SelectMany(a => a.GetTypes())
                .Where(t => t.GetInterface(typeof(IView).Name) != null && !t.IsAbstract && t.IsPublic);
        }

        private IEnumerable<Type> GetControllers()
        {
            return this.assemblies.SelectMany(a => a.GetTypes())
                .Where(t => t.GetInterface(typeof(IController).Name) != null && !t.IsAbstract && t.IsPublic);
        }

        private IEnumerable<Type> GetServices()
        {
            return this.assemblies.SelectMany(a => a.GetTypes())
                .Where(t => t.GetInterface(typeof(IService).Name) != null && !t.IsAbstract && t.IsPublic);
        }
    }
}
