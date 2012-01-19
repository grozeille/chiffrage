using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Commands
{
    public class CreateNewDealCommand : IEvent
    {
        private readonly string dealName;

        public CreateNewDealCommand(string dealName)
        {
            this.dealName = dealName;
        }

        public string DealName
        {
            get { return this.dealName; }
        }
    }
}
