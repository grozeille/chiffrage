using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Commands
{
    public class CopyDealCommand
    {
        public int DealId { get; private set; }

        public CopyDealCommand(int dealId)
        {
            this.DealId = dealId;
        }
    }
}
