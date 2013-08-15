using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Catalogs.Domain
{
    public class Task
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual TaskType Type { get; set; }
    }
}
