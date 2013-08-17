using Chiffrage.Projects.Domain;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace Chiffrage.Projects.Dal.Mappings
{
    public class ProjectMap : ClassMapping<Project>
    {
        public ProjectMap()
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

            this.Bag(x => x.OtherBenefits, y =>
            {
                y.Fetch(CollectionFetchMode.Join);
                //y.Lazy(CollectionLazy.Extra);
                y.BatchSize(10);
                y.Cascade(Cascade.All);
            },
            action => action.OneToMany());

            this.Bag(x => x.Frames, y =>
            {
                y.Fetch(CollectionFetchMode.Join);
                //y.Lazy(CollectionLazy.Extra);
                y.BatchSize(10);
                y.Cascade(Cascade.All);
            },
            action => action.OneToMany());

            this.Bag(x => x.Tasks, y =>
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