using Chiffrage.Catalogs.Domain;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace Chiffrage.Catalogs.Dal.Mappings
{
    public class HardwareTaskMap : ClassMapping<HardwareTask>
    {
        public HardwareTaskMap()
        {
            Id(x => x.Id, y =>
            {
                y.Generator(Generators.Identity);
            });
            Property(x => x.Value);
            this.ManyToOne(x => x.Task, y =>
            {
                y.Lazy(LazyRelation.NoLazy);
                y.Fetch(FetchKind.Join);
                y.Cascade(Cascade.Merge);
            });
        }
    }
}