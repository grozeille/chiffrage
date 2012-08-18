using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Module.Events
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