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

            Property(x => x.Name);
            Property(x => x.Category);
            Property(x => x.CatalogStudyDays);
            Property(x => x.CatalogReferenceDays);
            Property(x => x.CatalogTechnicianWorkDays);
            Property(x => x.CatalogWorkerWorkDays);
            Property(x => x.CatalogTestsDays);
            Property(x => x.StudyDays);
            Property(x => x.ReferenceDays);
            Property(x => x.TestsDays);
            Property(x => x.TestsNights);
            Property(x => x.TechnicianWorkDays);
            Property(x => x.TechnicianWorkShortNights);
            Property(x => x.TechnicianWorkLongNights);
            Property(x => x.WorkerWorkDays);
            Property(x => x.WorkerWorkShortNights);
            Property(x => x.WorkerWorkLongNights);
            Property(x => x.Milestone);

            this.Bag(x => x.Components, y =>
            {
                y.Fetch(CollectionFetchMode.Join);
                //y.Lazy(CollectionLazy.Extra);
                y.BatchSize(10);
                y.Cascade(Cascade.All);
            },
            action => action.OneToMany());

            this.Bag(x => x.Tasks, y =>
            {
                y.Fetch(CollectionFetchMode.Join);
                //y.Lazy(CollectionLazy.Extra);
                y.BatchSize(10);
                y.Cascade(Cascade.All);
            },
            action => action.OneToMany());
        }
    }
}