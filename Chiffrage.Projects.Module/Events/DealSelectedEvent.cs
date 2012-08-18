using Chiffrage.Mvc.Events;

namespace Chiffrage.App.Events
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