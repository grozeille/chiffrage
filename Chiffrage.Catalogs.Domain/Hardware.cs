using System.Collections.Generic;
using System.Linq;

namespace Chiffrage.Catalogs.Domain
{
    public class Hardware
    {
        private IList<HardwareSupply> components;

        private IList<HardwareTask> tasks;

        public Hardware()
        {
            this.components = new List<HardwareSupply>();
            this.tasks = new List<HardwareTask>();
        }

        public virtual IList<HardwareSupply> Components
        {
            get { return this.components; }
            set { this.components = value; }
        }

        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Category { get; set; }

        public virtual IList<HardwareTask> Tasks
        {
            get { return this.tasks; }
            set { this.tasks = value; }
        }
    }
}