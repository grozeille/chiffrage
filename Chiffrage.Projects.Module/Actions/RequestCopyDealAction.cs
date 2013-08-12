using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Module.Actions
{
    public class RequestCopyDealAction
    {
        public int DealId { get; private set; }

        public RequestCopyDealAction(int dealId)
        {
            this.DealId = dealId;
        }
    }
}
