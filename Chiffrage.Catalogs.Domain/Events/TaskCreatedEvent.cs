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
        private readonly int taskId;

        public TaskCreatedEvent(int taskId)
        {
            this.taskId = taskId;
        }

        public int TaskId { get { return this.taskId; } }
    }
}
