﻿using Chiffrage.Catalogs.Domain;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace Chiffrage.Catalogs.Dal.Mappings
{
    public class HardwareMap : ClassMapping<Hardware>
    {
        public HardwareMap()
        {
            Id(x => x.Id, y =>
            {
                y.Generator(Generators.Identity);
            });
            Property(x => x.Name);
            Property(x => x.Reference);
            Property(x => x.Category);
            Property(x => x.StudyDays);
            Property(x => x.ReferenceDays);
            Property(x => x.CatalogWorkDays);
            Property(x => x.CatalogExecutiveWorkDays);
            Property(x => x.CatalogTestsDays);
            this.Bag(x => x.Components, y =>
            {
                y.Fetch(CollectionFetchMode.Join);
                y.Lazy(CollectionLazy.NoLazy);
                y.Cascade(Cascade.All);
            },
            action => action.OneToMany());
        }
    }
}