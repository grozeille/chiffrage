using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Module.Events
{
    public class DealUnselectedEvent : IEvent
    {
        public DealUnselectedEvent(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}