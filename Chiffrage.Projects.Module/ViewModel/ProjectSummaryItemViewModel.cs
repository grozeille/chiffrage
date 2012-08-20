using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Projects.Module.ViewModel
{
    public class ProjectSummaryItemViewModel
    {
        public ProjectSummaryItemType ItemType { get; set; }

        public int ProjectId { get; set; }

        public int Quantity { get; set; }

        public string Name { get; set; }
    }
}
