using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Core;
using Chiffrage.Projects.Domain;

namespace Chiffrage.ViewModel
{
    public class ProjectHardwareViewModel : ProjectItemViewModel<ProjectHardware>
    {
        public double Milestone
        {
            get { return this.item.Milestone; }
            set { this.item.Milestone = value; }
        }
    }
}