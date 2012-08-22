using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Projects.Module.ViewModel
{
    public class ProjectWorkItemViewModel
    {
        public int ProjectId { get; set; }

        public int HardwareId { get; set; }

        public virtual double CatalogWorkDays { get; set; }

        public virtual double CatalogExecutiveWorkDays { get; set; }

        public virtual double WorkDays { get; set; }

        public virtual double ExecutiveWorkDays { get; set; }

        public double Quantity { get; set; }

        public virtual double TotalCatalogWorkDays { get; set; }

        public virtual double TotalCatalogExecutiveWorkDays { get; set; }

        public virtual double TotalWorkDays { get; set; }

        public virtual double TotalExecutiveWorkDays { get; set; }

    }
}
