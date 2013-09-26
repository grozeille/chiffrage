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
        private readonly int taskId;

        public TaskUpdatedEvent(int taskId)
        {
            this.taskId = taskId;
        }

        public int TaskId { get { return this.taskId; } }
    }
}
