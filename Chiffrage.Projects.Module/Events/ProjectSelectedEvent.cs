using Chiffrage.Mvc.Events;

namespace Chiffrage.App.Events
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