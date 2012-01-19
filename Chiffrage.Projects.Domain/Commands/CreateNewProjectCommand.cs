using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Commands
{
    public class CreateNewProjectCommand : IEvent
    {
        private readonly string projectName;

        private readonly int dealId;

        public CreateNewProjectCommand(int dealId, string projectName)
        {
            this.projectName = projectName;
            this.dealId = dealId;
        }

        public string ProjectName
        {
            get { return this.projectName; }
        }

        public int DealId
        {
            get { return this.dealId; }
        }
    }
}
