﻿using Chiffrage.Catalogs.Domain;
using FluentNHibernate.Mapping;

namespace Chiffrage.Catalogs.Dal.Mappings
{
    public class SupplierCatalogMap : ClassMap<SupplierCatalog>
    {
        public SupplierCatalogMap()
        {
            Id(x => x.Id);
            Map(x => x.Comment);
            Map(x => x.SupplierName);

            HasMany(x => x.Supplies)
                .Not.LazyLoad()
                .Cascade.All()
                .AsBag();
            HasMany(x => x.Hardwares)
                .Not.LazyLoad()
                .Cascade.All()
                .AsBag();
            HasMany(x => x.Cables)
                .Not.LazyLoad()
                .Cascade.All()
                .AsBag();
        }
    }
}