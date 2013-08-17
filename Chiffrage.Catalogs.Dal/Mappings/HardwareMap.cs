using Chiffrage.Catalogs.Domain;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace Chiffrage.Catalogs.Dal.Mappings
{
    public class HardwareMap : ClassMapping<Hardware>
    {
        public HardwareMap()
        {
            Id(x => x.Id, y =>
            {
                y.Generator(Generators.Identity);
            });
            Property(x => x.Name);
            Property(x => x.Category);
            this.Bag(x => x.Components, y =>
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