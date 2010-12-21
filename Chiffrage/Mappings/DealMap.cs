using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Core;
using Chiffrage.Projects.Domain;
using FluentNHibernate.Mapping;

namespace Chiffrage.Mappings
{
    public class DealMap : ClassMap<Deal>
    {
        public DealMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Reference);
            Map(x => x.Comment);
            Map(x => x.StartDate);
            Map(x => x.EndDate);
            HasMany(x => x.Projects)
                .Cascade.All()
                .AsBag();                
        }
    }
}
