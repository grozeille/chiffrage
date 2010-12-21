using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Domain;
using Chiffrage.Core;
using FluentNHibernate.Mapping;

namespace Chiffrage.Mappings
{
    public class HardwareMap : ClassMap<Hardware>
    {
        public HardwareMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Reference);
            Map(x => x.Category);
            HasMany(x => x.Components)
                .Cascade.SaveUpdate()
                .AsBag();                
        }
    }
}
