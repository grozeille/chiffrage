using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Projects.Module.ViewModel
{
    public class ProjectHardwareTechnicianWorkViewModel
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int CatalogId { get; set; }

        public string Name { get; set; }

        public double CatalogTechnicianWorkDays { get; set; }

        public double TechnicianWorkDays { get; set; }

        public double TechnicianWorkShortNights { get; set; }

        public double TechnicianWorkLongNights { get; set; }
    }
}
