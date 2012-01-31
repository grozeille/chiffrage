using System.Collections.Generic;
using System.Linq;
using Chiffrage.Core;

namespace Chiffrage.Catalogs.Domain
{
    public class Hardware
    {
        private IList<HardwareSupply> components;

        public Hardware()
        {
            this.components = new List<HardwareSupply>();
        }

        public virtual IList<HardwareSupply> Components
        {
            get { return this.components; }
            set { this.components = value; }
        }

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Reference { get; set; }
        public virtual string Category { get; set; }
    }
}