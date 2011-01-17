using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.App.Events
{
    public class CreateNewDealEvent : IEvent
    {
        private readonly string dealName;

        public CreateNewDealEvent(string dealName)
        {
            this.dealName = dealName;
        }

        public string DealName
        {
            get { return this.dealName; }
        }
    }
}
