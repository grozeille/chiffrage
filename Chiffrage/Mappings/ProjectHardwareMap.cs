using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Core;
using FluentNHibernate.Mapping;

namespace Chiffrage.Mappings
{
    public class ProjectHardwareMap : ClassMap<ProjectHardware>
    {
        public ProjectHardwareMap()
        {
            Id(x => x.Id);
            Map(x => x.Quantity);
            Map(x => x.Milestone);
            Map(x => x.Price);
            Map(x => x.WorkDays);
            Map(x => x.WorkShortNights);
            Map(x => x.WorkLongNights);
            Map(x => x.ExecutiveWorkDays);
            Map(x => x.ExecutiveWorkShortNights);
            Map(x => x.ExecutiveWorkLongNights);
            Map(x => x.TestsDays);
            Map(x => x.TestsNights);
            HasOne(x => x.Hardware);
        }
    }
}
