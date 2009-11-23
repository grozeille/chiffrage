using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Core;

namespace Chiffrage.Dto
{
    public class ProjectHardwareDto : ProjectItemDto<ProjectHardware>
    {
        public double Milestone
        {
            get { return this.item.Milestone; }
            set { this.item.Milestone = value; }
        }
    }
}
