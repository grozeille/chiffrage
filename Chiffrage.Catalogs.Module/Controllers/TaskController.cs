﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Controllers;
using Chiffrage.Catalogs.Domain.Repositories;
using Chiffrage.Catalogs.Module.Actions;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Views;
using Chiffrage.Catalogs.Module.Views;
using AutoMapper;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Catalogs.Module.ViewModel;
using Chiffrage.Common.Module.Actions;
using Chiffrage.Catalogs.Domain.Commands;
using Chiffrage.Catalogs.Domain.Events;

namespace Chiffrage.Catalogs.Module.Controllers
{
    public class TaskController : IController
    {
        private readonly ITaskRepository taskRepository;
        private readonly ILoadingView loadingView;
        private readonly ITasksView tasksView;

        private const string ViewModelTypeDay = "Jour";
        private const string ViewModelTypeDayAndNight = "Jour & Nuit";
        private const string ViewModelTypeDayAndLongNightAndShortNight = "Jour & Nuit longue & Nuit courte";

        public TaskController(ITaskRepository taskRepository, ILoadingView loadingView, ITasksView tasksView)
        {
            this.taskRepository = taskRepository;
            this.loadingView = loadingView;
            this.tasksView = tasksView;
        }

        [Publish]
        public event Action<UpdateTaskCommand> OnTaskUpdateCommand;

        [Publish]
        public event Action<CreateNewTaskCommand> OnCreateNewTaskCommand;

        [Subscribe]
        public void ProcessAction(TasksSelectedAction eventObject)
        {
            this.loadingView.Continuous = true;
            this.loadingView.ShowView();

            this.DisplayTasks();

            this.loadingView.HideView();
            this.tasksView.ShowView();
        }

        [Subscribe]
        public void ProcessAction(RequestNewTaskAction eventObject)
        {
            OnCreateNewTaskCommand(new CreateNewTaskCommand("Nouvelle tâche"));
        }

        [Subscribe]
        public void ProcessAction(CatalogUnselectedAction eventObject)
        {
            this.tasksView.DisplayTasks(null, null);
            this.tasksView.HideView();
        }

        private void DisplayTasks()
        {
            var tasks = this.taskRepository.FindAll();
            var tasksViewModel = new List<TaskViewModel>();
            foreach (var t in tasks)
            {
                tasksViewModel.Add(this.Convert(t));

            }

            this.tasksView.DisplayTasks(tasksViewModel, new String[]{ ViewModelTypeDay, ViewModelTypeDayAndNight, ViewModelTypeDayAndLongNightAndShortNight});
        }

        [Subscribe]
        public void ProcessAction(SaveAction eventObject)
        {
            var viewModel = this.tasksView.GetViewModel();
            if (viewModel == null)
            {
                return;
            }

            foreach (var item in viewModel)
            {
                TaskType taskType = TaskType.DAYS;
                switch (item.Type)
                {
                    case ViewModelTypeDay:
                        taskType = TaskType.DAYS;
                        break;
                    case ViewModelTypeDayAndNight:
                        taskType = TaskType.DAYS_NIGHT;
                        break;
                    case ViewModelTypeDayAndLongNightAndShortNight:
                        taskType = TaskType.DAYS_LONGNIGHT_SHORTNIGHT;
                        break;
                    default:
                        break;
                }
                OnTaskUpdateCommand(new UpdateTaskCommand(item.Id, item.Name, taskType));
            }
        }

        [Subscribe]
        public void ProcessAction(TaskCreatedEvent eventObject)
        {
            this.tasksView.AddTask(this.Convert(eventObject.Task));
        }

        [Subscribe]
        public void ProcessAction(TaskDeletedEvent eventObject)
        {
            this.tasksView.DeleteTask(eventObject.TaskId);
        }

        [Subscribe]
        public void ProcessAction(TaskUpdatedEvent eventObject)
        {
            this.tasksView.UpdateTask(this.Convert(eventObject.Task));
        }

        private TaskViewModel Convert(Task task)
        {
            TaskViewModel viewModel = new TaskViewModel();
            viewModel.Id = task.Id;
            viewModel.Name = task.Name;
            switch (task.Type)
            {
                case TaskType.DAYS:
                    viewModel.Type = ViewModelTypeDay;
                    break;
                case TaskType.DAYS_NIGHT:
                    viewModel.Type = ViewModelTypeDayAndNight;
                    break;
                case TaskType.DAYS_LONGNIGHT_SHORTNIGHT:
                    viewModel.Type = ViewModelTypeDayAndLongNightAndShortNight;
                    break;
                default:
                    break;
            }

            return viewModel;
        }
    }
}