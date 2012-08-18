using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Module.Events
{
    public class ProjectUnselectedEvent : IEvent
    {
        public ProjectUnselectedEvent(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}