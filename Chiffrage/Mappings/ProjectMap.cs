using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Core;
using FluentNHibernate.Mapping;

namespace Chiffrage.Mappings
{
    public class ProjectMap : ClassMap<Project>
    {
        public ProjectMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Reference);
            Map(x => x.Comment);
            Map(x => x.StartDate);
            Map(x => x.EndDate);
            
            Map(x => x.StudyRate);
            Map(x => x.ReferenceRate);
            Map(x => x.WorkDayRate);
            Map(x => x.WorkShortNightsRate);
            Map(x => x.WorkLongNightsRate);
            Map(x => x.TestDayRate);
            Map(x => x.TestNightRate);

            HasMany(x => x.Supplies)
                .Cascade.All()
                .AsBag();
            HasMany(x => x.Hardwares)
                .Cascade.All()
                .AsBag();
            HasMany(x => x.OtherBenefits)
                .Cascade.All()
                .AsBag();
        }
    }
}
