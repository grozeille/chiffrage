using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Module.Actions
{
    public class RequestDeleteProjectAction
    {
        public int DealId { get; private set; }

        public int ProjectId { get; private set; }

        public RequestDeleteProjectAction(int dealId, int projectId)
        {
            this.DealId = dealId;
            this.ProjectId = projectId;
        }
    }
}
