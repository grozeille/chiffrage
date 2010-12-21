using System.Collections.Generic;

namespace Chiffrage.Projects.Domain.Repositories
{
    public interface IProjectRepository
    {
        Project FindById(int projectId);

        IList<Project> FindAll();

        void Save(Project project);
    }
}