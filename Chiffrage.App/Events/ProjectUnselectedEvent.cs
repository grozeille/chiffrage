using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.App.Events
{
    public class ProjectUnselectedEvent : IEvent
    {
        public int Id { get; private set; }

        public ProjectUnselectedEvent(int id)
        {
            this.Id = id;
        }
    }
}
