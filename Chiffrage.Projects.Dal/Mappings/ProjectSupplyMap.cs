﻿using Chiffrage.Projects.Domain;
using FluentNHibernate.Mapping;

namespace Chiffrage.Projects.Dal.Mappings
{
    public class ProjectSupplyMap : ClassMap<ProjectSupply>
    {
        public ProjectSupplyMap()
        {
            Id(x => x.Id);
            Map(x => x.Quantity);
            //Map(x => x.Price);
            //Map(x => x.WorkDays);
            //Map(x => x.WorkShortNights);
            //Map(x => x.WorkLongNights);
            //Map(x => x.ExecutiveWorkDays);
            //Map(x => x.ExecutiveWorkShortNights);
            //Map(x => x.ExecutiveWorkLongNights);
            //Map(x => x.TestsDays);
            //Map(x => x.TestsNights);
            Map(x => x.CatalogId);

            Map(x => x.Name);
            Map(x => x.Reference);
            Map(x => x.Category);
            Map(x => x.ModuleSize);
            Map(x => x.CatalogPrice);
            Map(x => x.PFC0);
            Map(x => x.PFC12);
            Map(x => x.Cap);
        }
    }
}