using Chiffrage.Mvc.Events;

namespace Chiffrage.App.Events
{
    public class CatalogUnselectedEvent : IEvent
    {
        public CatalogUnselectedEvent(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}