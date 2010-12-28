using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.App.Events
{
    public interface IGenericEventHandler<T> :IEventHandler
        where T : IEvent
    {
        void ProcessAction(T eventObject);
    }
}