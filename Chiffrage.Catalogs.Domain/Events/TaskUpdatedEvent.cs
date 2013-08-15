using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.Catalogs.Domain.Events
{
    public class TaskUpdatedEvent
    {
        private readonly Task task;

        public TaskUpdatedEvent(Task task)
        {
            this.task = task;
        }

        public Task Task { get { return this.task; } }
    }
}
