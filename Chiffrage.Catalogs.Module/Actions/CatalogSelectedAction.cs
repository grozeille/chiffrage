using Chiffrage.Mvc.Events;

namespace Chiffrage.Catalogs.Module.Actions
{
    public class CatalogSelectedAction
    {
        public CatalogSelectedAction(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}