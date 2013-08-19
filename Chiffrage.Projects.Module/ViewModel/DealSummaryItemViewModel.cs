using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Projects.Module.ViewModel
{
    public class DealSummaryItemViewModel
    {
        public ProjectSummaryItemType ItemType { get; set; }

        public string Name { get; set; }

        public IList<DealSummaryProjectItemViewModel> ProjectItems { get; set; }
    }
}
