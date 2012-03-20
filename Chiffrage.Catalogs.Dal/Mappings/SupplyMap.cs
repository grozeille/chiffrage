using Chiffrage.Catalogs.Domain;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace Chiffrage.Catalogs.Dal.Mappings
{
    public class SupplyMap : ClassMapping<Supply>
    {
        public SupplyMap()
        {
            Id(x => x.Id, y =>
            {
                y.Generator(Generators.Identity);
            });
            Property(x => x.Name);
            Property(x => x.Reference);
            Property(x => x.Category);
            Property(x => x.ModuleSize);
            Property(x => x.CatalogPrice);
            Property(x => x.PFC0);
            Property(x => x.PFC12);
            Property(x => x.Cap);
        }
    }
}