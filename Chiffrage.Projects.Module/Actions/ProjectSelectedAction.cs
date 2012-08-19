using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Module.Actions
{
    public class ProjectSelectedAction : IEvent
    {
        public ProjectSelectedAction(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}