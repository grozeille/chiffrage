using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strongshell.Recoil.Core.Composition;
using Spring.Objects.Factory.Support;
using Spring.Objects.Factory.Config;

namespace Chiffrage.Ioc
{
    public abstract class ByTypeWiringContainer : WiringContainer
    {
        public override void SetupContainer()
        {
            foreach (var t in this.GetTypesToRegister())
            {
                var objectDefinitionBuilder = ObjectDefinitionBuilder.RootObjectDefinition(this.ObjectDefinitionFactory, t);
                var objectConfiguration = new ObjectConfiguration(objectDefinitionBuilder, t.FullName);
                objectConfiguration.Builder.SetAutowireMode(AutoWiringMode.Constructor);
                objectConfiguration.Builder.SetSingleton(true);
                this.ObjectConfigurations.Add(objectConfiguration);
            }
        }

        protected abstract IEnumerable<Type> GetTypesToRegister();
    }
}
