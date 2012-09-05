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

        public virtual double CatalogTechnicianWorkDays { get; set; }

        public virtual double CatalogWorkerWorkDays { get; set; }

        public virtual double TechnicianWorkDays { get; set; }

        public virtual double WorkerWorkDays { get; set; }

        public double Quantity { get; set; }

        public virtual double TotalCatalogTechnicianWorkDays { get; set; }

        public virtual double TotalCatalogWorkerWorkDays { get; set; }

        public virtual double TotalTechnicianWorkDays { get; set; }

        public virtual double TotalWorkerWorkDays { get; set; }

    }
}
