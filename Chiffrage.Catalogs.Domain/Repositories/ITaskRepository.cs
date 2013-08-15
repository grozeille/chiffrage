using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Catalogs.Domain.Repositories
{
    public interface ITaskRepository
    {
        void Save(Task task);

        IList<Task> FindAll();

        Task FindById(int taskId);

        void Delete(Task taskId);
    }
}
