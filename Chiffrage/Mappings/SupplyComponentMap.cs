﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Core;
using FluentNHibernate.Mapping;

namespace Chiffrage.Mappings
{
    public class SupplyComponentMap : ComponentMap<Supply>
    {
        public SupplyComponentMap()
        {
            Map(x => x.Id);
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