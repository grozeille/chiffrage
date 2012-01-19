using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Commands
{
    public class UpdateDealCommand : IEvent
    {
        private readonly int dealId;

        private readonly string name;

        private readonly string comment;

        private readonly string reference;

        private readonly DateTime startDate;

        private readonly DateTime endDate;

        public UpdateDealCommand(int dealId, string name, string comment, string reference, DateTime startDate, DateTime endDate)
        {
            this.dealId = dealId;
            this.name = name;
            this.comment = comment;
            this.reference = reference;
            this.startDate = startDate;
            this.endDate = endDate;
        }

        public int DealId { get { return this.dealId; } }

        public string Name { get { return this.name; } }

        public string Comment { get { return this.comment; } }

        public string Reference { get { return this.reference; } }

        public DateTime StartDate { get { return this.startDate; } }

        public DateTime EndDate { get { return this.endDate; } }
    }
}
