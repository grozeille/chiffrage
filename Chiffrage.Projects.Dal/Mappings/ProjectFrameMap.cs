using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Projects.Domain;
using FluentNHibernate.Mapping;

namespace Chiffrage.Projects.Dal.Mappings
{
    public class ProjectFrameMap : ClassMap<ProjectFrame>
    {
        public ProjectFrameMap()
        {
            this.Id(x => x.Id);
            this.Map(x => x.Count);
            this.Map(x => x.Size);
        }
    }
}
