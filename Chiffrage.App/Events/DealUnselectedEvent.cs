using Chiffrage.Mvc.Events;

namespace Chiffrage.App.Events
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