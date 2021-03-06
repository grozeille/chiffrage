﻿using System;
using System.Collections;
using System.Collections.Generic;
using Spring.Context;
using Spring.Objects.Factory;

namespace Chiffrage.Mvc.Events
{
    public class EventHandlersFactory : IFactoryObject, IApplicationContextAware
    {
        private IApplicationContext applicationContext;

        #region IApplicationContextAware Members

        public IApplicationContext ApplicationContext
        {
            set { this.applicationContext = value; }
        }

        #endregion

        #region IFactoryObject Members

        public object GetObject()
        {
            var result = new List<IEventHandler>();

            foreach (DictionaryEntry item in this.applicationContext.GetObjectsOfType(typeof (IEventHandler)))
            {
                result.Add((IEventHandler) item.Value);
            }

            return result.ToArray();
        }

        public bool IsSingleton
        {
            get { return true; }
        }

        public Type ObjectType
        {
            get { return typeof (IEventHandler[]); }
        }

        #endregion
    }
}