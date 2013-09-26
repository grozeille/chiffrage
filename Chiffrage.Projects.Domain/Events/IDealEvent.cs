using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Projects.Domain.Events
{
    public interface IDealEvent
    {
        int DealId { get; }
    }
}
