using Chiffrage.Catalogs.Domain;
using FluentNHibernate.Mapping;

namespace Chiffrage.Catalogs.Dal.Mappings
{
    public class HardwareMap : ClassMap<Hardware>
    {
        public HardwareMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Reference);
            Map(x => x.Category);
            Map(x => x.StudyDays);
            Map(x => x.ReferenceDays);
            Map(x => x.CatalogWorkDays);
            Map(x => x.CatalogExecutiveWorkDays);
            Map(x => x.CatalogTestsDays);
            HasMany(x => x.Components)
                .Not.LazyLoad()
                .Cascade.SaveUpdate()
                .AsBag();
        }
    }
}