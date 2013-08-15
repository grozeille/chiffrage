using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Commands
{
    public class DeleteProjectCommand
    {
        public int DealId { get; private set; }

        public int ProjectId { get; private set; }

        public DeleteProjectCommand(int dealId, int projectId)
        {
            this.DealId = dealId;
            this.ProjectId = projectId;
        }
    }
}
