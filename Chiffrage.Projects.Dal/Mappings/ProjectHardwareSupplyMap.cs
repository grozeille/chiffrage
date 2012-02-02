using Chiffrage.Projects.Domain;
using FluentNHibernate.Mapping;

namespace Chiffrage.Projects.Dal.Mappings
{
    public class ProjectHardwareSupplyMap : ClassMap<ProjectHardwareSupply>
    {
        public ProjectHardwareSupplyMap()
        {
            Id(x => x.Id);
            Map(x => x.Quantity);
            Map(x => x.Comment);
            References(x => x.Supply)
                .Not.LazyLoad()
                .Cascade.SaveUpdate();
        }
    }
}