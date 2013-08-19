using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Domain.Commands
{
    public class UpdateTaskCommand
    {
        private readonly int taskId;

        private readonly string name;

        private readonly TaskType type;

        private readonly TaskCategory category;

        private readonly int orderId;

        public UpdateTaskCommand(int taskId, string name, TaskType type, TaskCategory category, int orderId)
        {
            this.taskId = taskId;
            this.name = name;
            this.type = type;
            this.category = category;
            this.orderId = orderId;
        }

        public int TaskId { get { return this.taskId; } }

        public string Name { get { return this.name; } }

        public TaskType Type { get { return this.type; } }

        public TaskCategory Category { get { return this.category; } }

        public int OrderId { get { return this.orderId; } }
    }
}
