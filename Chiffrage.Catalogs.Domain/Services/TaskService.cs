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
        private readonly ICatalogRepository catalogRepository;

        public TaskService(
            IEventBroker eventBroker,
            ITaskRepository repository,
            ICatalogRepository catalogRepository)
        {
            this.repository = repository;
            this.catalogRepository = catalogRepository;
            this.eventBroker = eventBroker;
        }

        [Subscribe]
        public void ProcessAction(CreateNewTaskCommand eventObject)
        {
            var tasks = this.repository.FindAll();

            var task = new Task();
            task.Name = eventObject.Name;
            task.Type = TaskType.DAYS;
            task.Category = TaskCategory.STUDY;
            task.OrderId = tasks.Count == 0 ? 0 : tasks.Max(x => x.OrderId) + 1;

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
            task.Category = eventObject.Category;

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
                task.Category = item.Category;
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

            var catalogs = this.catalogRepository.FindAll();
            foreach(var catalog in catalogs)
            {
                bool toSave = false;
                foreach(var hardware in catalog.Hardwares)
                {
                    var found = hardware.Tasks.Where(x => x.Task.Id == task.Id).FirstOrDefault();
                    if(found != null)
                    {
                        hardware.Tasks.Remove(found);
                        toSave = true;
                    }
                }

                if (toSave)
                {
                    this.catalogRepository.Save(catalog);
                    this.eventBroker.Publish(new CatalogUpdatedEvent(catalog));
                }
            }

            this.repository.Delete(task);

            this.eventBroker.Publish(new TaskDeletedEvent(task.Id));

            var tasks = this.repository.FindAll().OrderBy(x => x.OrderId);
            var tasksToNotifyUpdated = new List<Task>();
            int cpt = 0;
            foreach(var item in tasks)
            {
                if (item.OrderId != cpt)
                {
                    item.OrderId = cpt;
                    tasksToNotifyUpdated.Add(item);
                }
                cpt++;
            }

            foreach (var item in tasksToNotifyUpdated)
            {
                this.eventBroker.Publish(new TaskUpdatedEvent(item));
            }
        }
    }
}
