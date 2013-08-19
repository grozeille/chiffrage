using Chiffrage.Projects.Domain;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace Chiffrage.Projects.Dal.Mappings
{
    public class ProjectHardwareTaskMap : ClassMapping<ProjectHardwareTask>
    {
        public ProjectHardwareTaskMap()
        {
            Id(x => x.Id, y =>
            {
                y.Generator(Generators.Identity);
            });

            Property(x => x.HardwareTaskId);
            Property(x => x.Value);
            Property(x => x.CatalogValue);
            Property(x => x.HardwareTaskType);

            this.ManyToOne(x => x.Task, y =>
            {
                //y.Lazy(LazyRelation.Proxy);
                y.Fetch(FetchKind.Join);
                y.Cascade(Cascade.Merge);
            });
        }
    }
}