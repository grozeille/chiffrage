using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grozeille.Chiffrage.Core
{
    public class Deal
    {
        public string Name { get; set; }

        public IList<Project> Projects { get; set; }

        public Deal()
        {
            this.Projects = new List<Project>();
        }
    }
}
