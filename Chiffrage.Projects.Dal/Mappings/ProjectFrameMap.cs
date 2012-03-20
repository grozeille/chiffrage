using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Projects.Domain;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;

namespace Chiffrage.Projects.Dal.Mappings
{
    public class ProjectFrameMap : ClassMapping<ProjectFrame>
    {
        public ProjectFrameMap()
        {
            this.Id(x => x.Id, y =>
            {
                y.Generator(Generators.Identity);
            });
            this.Property(x => x.Count);
            this.Property(x => x.Size);
        }
    }
}
