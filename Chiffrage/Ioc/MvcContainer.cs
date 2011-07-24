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

namespace Chiffrage.Ioc
{
    public class MvcContainer : ByTypeWiringContainer
    {
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
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.FullName.StartsWith("Chiffrage"))
                .SelectMany(a => a.GetTypes())
                .Where(t => t.GetInterface(typeof(IView).Name) != null && !t.IsAbstract && t.IsPublic);
        }

        private IEnumerable<Type> GetControllers()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.FullName.StartsWith("Chiffrage"))
                .SelectMany(a => a.GetTypes())
                .Where(t => t.GetInterface(typeof(IController).Name) != null && !t.IsAbstract && t.IsPublic);
        }

        protected override IEnumerable<Type> GetTypesToRegister()
        {
            return this.GetViews().Concat(this.GetControllers());            
        }
    }
}