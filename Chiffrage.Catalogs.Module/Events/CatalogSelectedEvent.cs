using Chiffrage.Mvc.Events;

namespace Chiffrage.App.Events
{
    public class CatalogSelectedEvent : IEvent
    {
        public CatalogSelectedEvent(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}