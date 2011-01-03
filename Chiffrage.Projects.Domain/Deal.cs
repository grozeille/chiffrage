using System;
using System.Collections.Generic;

namespace Chiffrage.Projects.Domain
{
    public class Deal
    {
        public Deal()
        {
            this.Projects = new List<Project>();
        }

        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Reference { get; set; }

        public virtual string Comment { get; set; }

        public virtual DateTime StartDate { get; set; }

        public virtual DateTime EndDate { get; set; }

        public virtual IList<Project> Projects { get; set; }
    }
}