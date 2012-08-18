using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Module.Events
{
    public class ProjectSelectedEvent : IEvent
    {
        public ProjectSelectedEvent(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}