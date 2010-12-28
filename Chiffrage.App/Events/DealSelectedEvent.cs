using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.App.Events
{
    public class DealSelectedEvent : IEvent
    {
        public int Id { get; private set; }

        public DealSelectedEvent(int id)
        {
            this.Id = id;
        }
    }
}
