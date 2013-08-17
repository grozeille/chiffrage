using Chiffrage.Catalogs.Domain;
using System.Collections.Generic;

namespace Chiffrage.Projects.Domain
{
    public class ProjectHardware
    {
        private IList<ProjectHardwareSupply> components;

        private IList<ProjectHardwareTask> tasks;

        public ProjectHardware()
        {
            this.components = new List<ProjectHardwareSupply>();
            this.tasks = new List<ProjectHardwareTask>();
        }

        public virtual IList<ProjectHardwareSupply> Components
        {
            get { return this.components; }
            set { this.components = value; }
        }

        public virtual IList<ProjectHardwareTask> Tasks
        {
            get { return this.tasks; }
            set { this.tasks = value; }
        }

        public virtual int Id { get; set; }

        public virtual int CatalogId { get; set; }

        public virtual int HardwareId { get; set; }

        public virtual string Name { get; set; }

        public virtual string Category { get; set; }

        public virtual double Milestone { get; set; }
    }
}