using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.EventStore.Repositories
{
    public interface IEventRepository
    {
        void Save(EventObject eventObject);
    }
}
