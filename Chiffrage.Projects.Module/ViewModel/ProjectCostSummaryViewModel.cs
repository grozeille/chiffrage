using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Projects.Module.ViewModel
{
    public class ProjectCostSummaryViewModel
    {
        public ProjectCostSummaryType ProjectCostSummaryType { get; set; }

        public string Name { get; set; }

        public double Rate { get; set; }

        public double TotalTime { get; set; }

        public double TotalCost { get; set; }
    }
}
