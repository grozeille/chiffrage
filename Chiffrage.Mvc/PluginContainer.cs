using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Objects.Factory.Config;
using Strongshell.Recoil.Core.Composition;

namespace Chiffrage.Mvc
{
    public abstract class PluginContainer : WiringContainer
    {
        public override void SetupContainer()
        {
            Type[] views = this.GetViews();

            Type[] controllers = this.GetControllers();

            this.OnSetup();

            foreach(var v in views)
            {
                Type viewType = v;
                Define(() => viewType)
                    .AutoWire(AutoWiringMode.Constructor)
                    .LazyInit(true)
                    .AsSingleton();
            }

            foreach (var c in controllers)
            {
                Type controllerType = c;
                Define(() => controllerType)
                    .AutoWire(AutoWiringMode.Constructor)
                    .LazyInit(true)
                    .AsSingleton();
            }
        }

        protected abstract void OnSetup();

        protected abstract Type[] GetControllers();

        protected abstract Type[] GetViews();
    }
}
