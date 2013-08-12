using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Module.Actions
{
    public class RequestDeleteDealAction
    {
        public int DealId { get; private set; }

        public RequestDeleteDealAction(int dealId)
        {
            this.DealId = dealId;
        }
    }
}
