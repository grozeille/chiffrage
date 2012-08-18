using Chiffrage.Mvc.Events;

namespace Chiffrage.App.Events
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