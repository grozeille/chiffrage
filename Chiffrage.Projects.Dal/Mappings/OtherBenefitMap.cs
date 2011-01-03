using Chiffrage.Projects.Domain;
using FluentNHibernate.Mapping;

namespace Chiffrage.Projects.Dal.Mappings
{
    public class OtherBenefitMap : ClassMap<OtherBenefit>
    {
        public OtherBenefitMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Days);
            Map(x => x.CostRate);
        }
    }
}