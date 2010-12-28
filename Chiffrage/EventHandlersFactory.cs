using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.App.Events;
using Spring.Objects.Factory;
using Spring.Context;

namespace Chiffrage
{
    public class EventHandlersFactory : IFactoryObject, IApplicationContextAware
    {
        private IApplicationContext applicationContext;

        #region IFactoryObject Members

        public object GetObject()
        {
            var result = new List<IEventHandler>();

            foreach (DictionaryEntry item in applicationContext.GetObjectsOfType(typeof(IEventHandler)))
            {
                result.Add((IEventHandler)item.Value);
            }

            return result.ToArray();
        }

        public bool IsSingleton
        {
            get { return true; }
        }

        public Type ObjectType
        {
            get { return typeof(IEventHandler[]); }
        }

        #endregion

        #region IApplicationContextAware Members

        public IApplicationContext ApplicationContext
        {
            set { this.applicationContext = value; }
        }

        #endregion
    }
}
