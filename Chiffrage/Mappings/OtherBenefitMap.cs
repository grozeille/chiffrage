using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Core;
using FluentNHibernate.Mapping;

namespace Chiffrage.Mappings
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
