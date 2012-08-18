using System.Linq;
using System;
using Chiffrage.App.Controllers;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Views;
using Spring.Aop.Framework.AutoProxy;
using Spring.Objects.Factory.Config;
using Strongshell.Recoil.Core.Composition;
using System.Reflection;
using Spring.Context.Support;
using Spring.Objects.Factory.Support;
using System.Collections.Generic;
using Chiffrage.Mvc.Controllers;
using Chiffrage.Mvc.Services;

namespace Chiffrage.Ioc
{
    public class MvcContainer : ByTypeWiringContainer
    {
        private IEnumerable<Assembly> assemblies;

        public override void SetupContainer()
        {
            Define<EventBroker>()
                .AutoWire(AutoWiringMode.ByType)
                .AsSingleton();

            Define<EventHandlersFactory>()
                .AsSingleton();

            base.SetupContainer();
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

        protected override IEnumerable<Type> GetTypesToRegister()
        {
            // force load referenced assemblies
            this.assemblies = Assembly.GetExecutingAssembly()
                .GetReferencedAssemblies()
                .Where(x => x.FullName.StartsWith("Chiffrage"))
                .Select(x => Assembly.Load(x))
                .Union(new Assembly[] { Assembly.GetExecutingAssembly() })
                .ToArray();

            return this.GetViews()
                .Concat(this.GetControllers())
                .Concat(this.GetServices());
        }
    }
}