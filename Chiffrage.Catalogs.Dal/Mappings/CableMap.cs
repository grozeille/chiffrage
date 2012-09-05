using Chiffrage.Catalogs.Domain;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace Chiffrage.Catalogs.Dal.Propertypings
{
    public class CableProperty : ClassMapping<Cable>
    {
        public CableProperty()
        {
            Id(x => x.Id, y =>
            {
                y.Generator(Generators.Identity);
            });
            Property(x => x.Name);
            Property(x => x.Reference);
            Property(x => x.Category);
            Property(x => x.ModuleSize);
            Property(x => x.PricePerMeter);
            Property(x => x.Length);
            Property(x => x.StudyDays);
            Property(x => x.ReferenceDays);
            Property(x => x.CatalogTechnicianWorkDays);
            Property(x => x.CatalogWorkerWorkDays);
            Property(x => x.CatalogTestsDays);
        }
    }
}