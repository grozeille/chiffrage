using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Core;
using FluentNHibernate.Mapping;

namespace Chiffrage.Catalogs.Dal.Mappings
{
    public class SupplyMap : ClassMap<Supply>
    {
        public SupplyMap()
        {
            Id(x => x.Id);
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