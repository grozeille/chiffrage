using Chiffrage.Projects.Domain;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace Chiffrage.Projects.Dal.Mappings
{
    public class ProjectSupplyMap : ClassMapping<ProjectSupply>
    {
        public ProjectSupplyMap()
        {
            Id(x => x.Id, y =>
                {
                    y.Generator(Generators.Identity);
                });
            Property(x => x.Quantity);
            Property(x => x.CatalogId);
            Property(x => x.SupplyId);

            Property(x => x.Name);
            Property(x => x.Reference);
            Property(x => x.Category);
            Property(x => x.ModuleSize);
            Property(x => x.CatalogPrice);
            Property(x => x.Price);
            Property(x => x.PFC0);
            Property(x => x.PFC12);
            Property(x => x.Cap);
        }
    }
}