using Chiffrage.Catalogs.Domain;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace Chiffrage.Catalogs.Dal.Mappings
{
    public class HardwareSupplyMap : ClassMapping<HardwareSupply>
    {
        public HardwareSupplyMap()
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
                    y.Cascade(Cascade.Merge);
                });
        }
    }
}