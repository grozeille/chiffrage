using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Views;
using Chiffrage.Catalogs.Module.ViewModel;

namespace Chiffrage.Catalogs.Module.Views
{
    public interface ITasksView : IView
    {
        void DisplayTasks(IList<TaskViewModel> tasks, String[] taskTypes, String[] taskCategories);

        IList<TaskViewModel> GetViewModel();

        void DeleteTask(int taskId);

        void AddTask(TaskViewModel task);

        void UpdateTask(TaskViewModel task);
    }
}
