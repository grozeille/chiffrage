using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Core;
using Chiffrage.Projects.Domain;
using FluentNHibernate.Mapping;

namespace Chiffrage.Projects.Dal.Mappings
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

            Map(x => x.Name);
            Map(x => x.Reference);
            Map(x => x.Category);
            Map(x => x.ModuleSize);
            Map(x => x.CatalogPrice);
            Map(x => x.StudyDays);
            Map(x => x.ReferenceDays);
            Map(x => x.CatalogWorkDays);
            Map(x => x.CatalogExecutiveWorkDays);
            Map(x => x.CatalogTestsDays);
        }
    }
}