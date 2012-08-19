using Chiffrage.Projects.Domain;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace Chiffrage.Projects.Dal.Mappings
{
    public class ProjectHardwareMap : ClassMapping<ProjectHardware>
    {
        public ProjectHardwareMap()
        {
            Id(x => x.Id, y =>
            {
                y.Generator(Generators.Identity);
            });
            Property(x => x.Quantity);
            //Property(x => x.Milestone);
            //Property(x => x.Price);
            //Property(x => x.WorkDays);
            //Property(x => x.WorkShortNights);
            //Property(x => x.WorkLongNights);
            //Property(x => x.ExecutiveWorkDays);
            //Property(x => x.ExecutiveWorkShortNights);
            //Property(x => x.ExecutiveWorkLongNights);
            //Property(x => x.TestsDays);
            //Property(x => x.TestsNights);

            Property(x => x.Name);
            Property(x => x.Reference);
            Property(x => x.Category);
            Property(x => x.CatalogStudyDays);
            Property(x => x.CatalogReferenceDays);
            Property(x => x.CatalogWorkDays);
            Property(x => x.CatalogExecutiveWorkDays);
            Property(x => x.CatalogTestsDays);
            Property(x => x.StudyDays);
            Property(x => x.ReferenceDays);
            Property(x => x.WorkDays);
            Property(x => x.ExecutiveWorkDays);
            Property(x => x.TestsDays);

            this.Bag(x => x.Components, y =>
            {
                y.Fetch(CollectionFetchMode.Join);
                y.Lazy(CollectionLazy.NoLazy);
                y.Cascade(Cascade.All);
            },
            action => action.OneToMany());
        }
    }
}