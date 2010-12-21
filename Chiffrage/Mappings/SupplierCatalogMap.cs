using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Core;
using FluentNHibernate.Mapping;

namespace Chiffrage.Mappings
{
    public class SupplierCatalogMap : ClassMap<SupplierCatalog>
    {
        public SupplierCatalogMap()
        {
            Id(x => x.Id);
            Map(x => x.Comment);
            Map(x => x.SupplierName);
            
            HasMany(x => x.Supplies)
                .Cascade.All()
                .AsBag();
            HasMany(x => x.Hardwares)
                .Cascade.All()
                .AsBag();
            HasMany(x => x.Cables)
                .Cascade.All()
                .AsBag();
        }
    }
}
