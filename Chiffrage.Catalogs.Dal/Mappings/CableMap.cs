using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Core;
using FluentNHibernate.Mapping;

namespace Chiffrage.Catalogs.Dal.Mappings
{
    public class CableMap : ClassMap<Cable>
    {
        public CableMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Reference);
            Map(x => x.Category);
            Map(x => x.ModuleSize);
            Map(x => x.PricePerMeter);
            Map(x => x.Length);
            Map(x => x.StudyDays);
            Map(x => x.ReferenceDays);
            Map(x => x.CatalogWorkDays);
            Map(x => x.CatalogExecutiveWorkDays);
            Map(x => x.CatalogTestsDays);
        }
    }
}