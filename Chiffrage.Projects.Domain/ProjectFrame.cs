using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Projects.Domain
{
    public class ProjectFrame
    {
        public virtual int Id { get; set; }

        public virtual int Size { get; set; }

        public virtual int Count { get; set; }
    }
}
