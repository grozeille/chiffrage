using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Services;
using Chiffrage.Mvc.Events;
using Chiffrage.Catalogs.Domain.Repositories;
using Chiffrage.Catalogs.Domain.Commands;
using Chiffrage.Catalogs.Domain.Events;

namespace Chiffrage.Catalogs.Domain.Services
{
    public class TaskService : IService
    {
        private readonly IEventBroker eventBroker;
        private readonly ITaskRepository repository;

        public TaskService(
            IEventBroker eventBroker,
            ITaskRepository repository)
        {
            this.repository = repository;
            this.eventBroker = eventBroker;
        }

        [Subscribe]
        public void ProcessAction(CreateNewTaskCommand eventObject)
        {
            var task = new Task();
            task.Name = eventObject.Name;
            task.Type = TaskType.DAYS;

            this.repository.Save(task);

            this.eventBroker.Publish(new TaskCreatedEvent(task));
        }

        [Subscribe]
        public void ProcessAction(UpdateTaskCommand eventObject)
        {
            var task = this.repository.FindById(eventObject.TaskId);
            task.Name = eventObject.Name;
            task.Type = eventObject.Type;
            task.OrderId = eventObject.OrderId;

            this.repository.Save(task);

            this.eventBroker.Publish(new TaskUpdatedEvent(task));
        }

        [Subscribe]
        public void ProcessAction(UpdateTaskListCommand eventObject)
        {
            var tasks = new List<Task>();
            foreach (var item in eventObject.Tasks)
            {
                var task = this.repository.FindById(item.TaskId);
                task.Name = item.Name;
                task.Type = item.Type;
                task.OrderId = item.OrderId;
                tasks.Add(task);
            }

            this.repository.Save(tasks);

            foreach (var item in tasks)
            {
                this.eventBroker.Publish(new TaskUpdatedEvent(item));
            }
        }

        [Subscribe]
        public void ProcessAction(DeleteTaskCommand eventObject)
        {
            var task = this.repository.FindById(eventObject.TaskId);

            this.repository.Delete(task);

            this.eventBroker.Publish(new TaskDeletedEvent(task.Id));
        }
    }
}
