using Chiffrage.Projects.Domain;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace Chiffrage.Projects.Dal.Mappings
{
    public class ProjectHardwareSupplyMap : ClassMapping<ProjectHardwareSupply>
    {
        public ProjectHardwareSupplyMap()
        {
            Id(x => x.Id, y =>
            {
                y.Generator(Generators.Identity);
            });
            Property(x => x.Quantity);
            Property(x => x.Comment);
            this.ManyToOne(x => x.Supply, y =>
            {
                //y.Lazy(LazyRelation.Proxy);
                y.Fetch(FetchKind.Join);
                y.Cascade(Cascade.All);
            });
        }
    }
}