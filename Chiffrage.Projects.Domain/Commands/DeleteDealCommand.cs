using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Commands
{
    public class DeleteDealCommand
    {
        public int DealId { get; private set; }

        public DeleteDealCommand(int dealId)
        {
            this.DealId = dealId;
        }
    }
}
