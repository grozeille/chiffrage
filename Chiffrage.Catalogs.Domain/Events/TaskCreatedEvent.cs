using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Events
{
    public class TaskCreatedEvent
    {
        private readonly Task task;

        public TaskCreatedEvent(Task task)
        {
            this.task = task;
        }

        public Task Task { get { return this.task; } }
    }
}
