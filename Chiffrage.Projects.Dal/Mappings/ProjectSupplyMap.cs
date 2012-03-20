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
            //Property(x => x.Price);
            //Property(x => x.WorkDays);
            //Property(x => x.WorkShortNights);
            //Property(x => x.WorkLongNights);
            //Property(x => x.ExecutiveWorkDays);
            //Property(x => x.ExecutiveWorkShortNights);
            //Property(x => x.ExecutiveWorkLongNights);
            //Property(x => x.TestsDays);
            //Property(x => x.TestsNights);
            Property(x => x.CatalogId);

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