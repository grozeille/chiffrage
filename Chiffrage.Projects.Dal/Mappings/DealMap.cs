using Chiffrage.Projects.Domain;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace Chiffrage.Projects.Dal.Mappings
{
    public class DealMap : ClassMapping<Deal>
    {
        public DealMap()
        {
            Id(x => x.Id, y =>
            {
                y.Generator(Generators.Identity);
            });
            Property(x => x.Name);
            Property(x => x.Reference);
            Property(x => x.Comment);
            Property(x => x.StartDate);
            Property(x => x.EndDate);
            this.Bag(x => x.Projects, y =>
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