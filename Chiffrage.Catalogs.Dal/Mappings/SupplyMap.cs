using Chiffrage.Catalogs.Domain;
using FluentNHibernate.Mapping;

namespace Chiffrage.Catalogs.Dal.Mappings
{
    public class SupplyMap : ClassMap<Supply>
    {
        public SupplyMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Reference);
            Map(x => x.Category);
            Map(x => x.ModuleSize);
            Map(x => x.CatalogPrice);
            Map(x => x.PFC0);
            Map(x => x.PFC12);
            Map(x => x.Cap);
        }
    }
}