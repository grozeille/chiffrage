using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Projects.Module.ViewModel
{
    public class ProjectHardwareExecutiveWorkViewModel
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int CatalogId { get; set; }

        public string Name { get; set; }

        public double CatalogExecutiveWorkDays { get; set; }

        public double ExecutiveWorkDays { get; set; }

        public double ExecutiveWorkShortNights { get; set; }

        public double ExecutiveWorkLongNights { get; set; }

        public int Quantity { get; set; }

        public double TotalCatalogExecutiveWorkDays { get; set; }

        public double TotalExecutiveWorkDays { get; set; }

        public double TotalExecutiveWorkShortNights { get; set; }

        public double TotalExecutiveWorkLongNights { get; set; }
    }
}
