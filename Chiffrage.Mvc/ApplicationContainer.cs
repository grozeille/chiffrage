using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;
using Spring.Objects.Factory.Config;
using Strongshell.Recoil.Core.Composition;

namespace Chiffrage.Mvc
{
    public class ApplicationContainer : WiringContainer
    {
        public override void SetupContainer()
        {
            Define<EventBroker>()
               .AutoWire(AutoWiringMode.ByType)
               .AsSingleton();

            Define<EventHandlersFactory>()
                .AsSingleton();

            Define<ApplicationForm>()
               .AutoWire(AutoWiringMode.Constructor)
               .LazyInit(true)
               .AsSingleton();
        }
    }
}
