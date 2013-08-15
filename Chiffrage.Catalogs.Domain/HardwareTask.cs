using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Catalogs.Domain
{
    public class HardwareTask
    {
        public virtual int Id { get; set; }

        public virtual Task Task { get; set; }

        public virtual double Value { get; set; }
    }
}
