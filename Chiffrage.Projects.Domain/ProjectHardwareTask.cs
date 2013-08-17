using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.Projects.Domain
{
    public class ProjectHardwareTask
    {
        public virtual int Id { get; set; }

        public virtual int HardwareTaskId { get; set; }

        public virtual int TaskId { get; set; }

        public virtual string Name { get; set; }

        public virtual double Value { get; set; }

        public virtual double CatalogValue { get; set; }

        public virtual TaskType TaskType { get; set; }
        
        public virtual ProjectHardwareTaskType HardwareTaskType { get; set; }
    }
}
