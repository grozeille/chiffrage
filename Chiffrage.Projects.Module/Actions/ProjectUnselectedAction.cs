using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Module.Actions
{
    public class ProjectUnselectedAction
    {
        public ProjectUnselectedAction(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}