using Chiffrage.Catalogs.Domain;
using System.Collections.Generic;

namespace Chiffrage.Projects.Domain
{
    public class ProjectHardware
    {
        private IList<ProjectHardwareSupply> components;

        public ProjectHardware()
        {
            this.components = new List<ProjectHardwareSupply>();
        }

        public virtual IList<ProjectHardwareSupply> Components
        {
            get { return this.components; }
            set { this.components = value; }
        }

        public virtual int Id { get; set; }

        public virtual int CatalogId { get; set; }

        public virtual int HardwareId { get; set; }

        public virtual int Quantity { get; set; }

        public virtual string Name { get; set; }

        public virtual string Reference { get; set; }

        public virtual string Category { get; set; }
    }
}