using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Core;
using FluentNHibernate.Mapping;

namespace Chiffrage.Mappings
{
    public class ProjectSupplyMap : ClassMap<ProjectSupply>
    {
        public ProjectSupplyMap()
        {
            Id(x => x.Id);
            Map(x => x.Quantity);
            Map(x => x.Price);
            Map(x => x.WorkDays);
            Map(x => x.WorkShortNights);
            Map(x => x.WorkLongNights);
            Map(x => x.ExecutiveWorkDays);
            Map(x => x.ExecutiveWorkShortNights);
            Map(x => x.ExecutiveWorkLongNights);
            Map(x => x.TestsDays);
            Map(x => x.TestsNights);
            Component(x => x.Supply)
                .ColumnPrefix("Supply_");
        }
    }
}
