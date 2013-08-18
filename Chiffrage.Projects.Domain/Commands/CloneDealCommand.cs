using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Commands
{
    public class CloneDealCommand
    {
        public int DealId { get; private set; }

        public CloneDealCommand(int dealId)
        {
            this.DealId = dealId;
        }
    }
}
