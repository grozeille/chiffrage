using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Module.Actions
{
    public class ProjectCopyAction
    {
        public ProjectCopyAction(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}