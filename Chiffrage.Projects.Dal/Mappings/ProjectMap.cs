using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Core;
using Chiffrage.Projects.Domain;
using FluentNHibernate.Mapping;

namespace Chiffrage.Projects.Dal.Mappings
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
                .Not.LazyLoad()
                .AsBag();
            HasMany(x => x.Hardwares)
                .Cascade.All()
                .Not.LazyLoad()
                .AsBag();
            HasMany(x => x.OtherBenefits)
                .Cascade.All()
                .Not.LazyLoad()
                .AsBag();
        }
    }
}