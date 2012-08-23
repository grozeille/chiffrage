using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Projects.Module.ViewModel
{
    public class ProjectHardwareWorkViewModel
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int CatalogId { get; set; }

        public string Name { get; set; }

        public double CatalogWorkDays { get; set; }

        public double WorkDays { get; set; }

        public double WorkShortNights { get; set; }

        public double WorkLongNights { get; set; }
    }
}
