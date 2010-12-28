using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.App.Events
{
    public class CatalogSelectedEvent : IEvent
    {
        public int Id { get; private set; }

        public CatalogSelectedEvent(int id)
        {
            this.Id = id;
        }
    }
}
