using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Module.Actions
{
    public class CatalogUnselectedAction
    {
        public CatalogUnselectedAction(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}