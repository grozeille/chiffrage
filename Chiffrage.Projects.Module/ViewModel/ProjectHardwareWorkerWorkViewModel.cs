using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Projects.Module.ViewModel
{
    public class ProjectHardwareWorkerWorkViewModel
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int CatalogId { get; set; }

        public string Name { get; set; }

        public double CatalogWorkerWorkDays { get; set; }

        public double WorkerWorkDays { get; set; }

        public double WorkerWorkShortNights { get; set; }

        public double WorkerWorkLongNights { get; set; }
    }
}
