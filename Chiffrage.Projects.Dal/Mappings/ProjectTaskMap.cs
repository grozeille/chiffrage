using Chiffrage.Projects.Domain;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace Chiffrage.Projects.Dal.Mappings
{
    public class ProjectTaskMap : ClassMapping<ProjectTask>
    {
        public ProjectTaskMap()
        {
            Id(x => x.Id, y =>
            {
                y.Generator(Generators.Identity);
            });

            Property(x => x.Name);
            Property(x => x.TaskId);
            Property(x => x.TaskType);
            Property(x => x.DayRate);
            Property(x => x.NightRate);
            Property(x => x.LongNightRate);
            Property(x => x.ShortNightRate);
        }
    }
}