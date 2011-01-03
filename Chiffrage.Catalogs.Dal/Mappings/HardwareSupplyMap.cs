using Chiffrage.Catalogs.Domain;
using FluentNHibernate.Mapping;

namespace Chiffrage.Catalogs.Dal.Mappings
{
    public class HardwareSupplyMap : ClassMap<HardwareSupply>
    {
        public HardwareSupplyMap()
        {
            Id(x => x.Id);
            Map(x => x.Quantity);
            HasOne(x => x.Supply).Not.LazyLoad();
        }
    }
}