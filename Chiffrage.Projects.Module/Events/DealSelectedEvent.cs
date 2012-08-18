using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Module.Events
{
    public class DealSelectedEvent : IEvent
    {
        public DealSelectedEvent(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}