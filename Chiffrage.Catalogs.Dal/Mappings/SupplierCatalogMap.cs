using Chiffrage.Catalogs.Domain;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace Chiffrage.Catalogs.Dal.Mappings
{
    public class SupplierCatalogMap : ClassMapping<SupplierCatalog>
    {
        public SupplierCatalogMap()
        {
            Id(x => x.Id, y =>
            {
                y.Generator(Generators.Identity);
            });
            Property(x => x.Comment);
            Property(x => x.SupplierName);

            this.Bag(x => x.Supplies, y =>
            {
                y.Fetch(CollectionFetchMode.Join);
                //y.Lazy(CollectionLazy.Extra);
                y.BatchSize(10);
                y.Cascade(Cascade.All);
            },
            action => action.OneToMany());

            this.Bag(x => x.Hardwares, y =>
            {
                y.Fetch(CollectionFetchMode.Join);
                //y.Lazy(CollectionLazy.Extra);
                y.BatchSize(10);
                y.Cascade(Cascade.All);
            },
            action => action.OneToMany());

            this.Bag(x => x.Cables, y =>
            {
                y.Fetch(CollectionFetchMode.Join);
                //y.Lazy(CollectionLazy.Extra);
                y.BatchSize(10);
                y.Cascade(Cascade.All);
            },
            action => action.OneToMany());
        }
    }
}