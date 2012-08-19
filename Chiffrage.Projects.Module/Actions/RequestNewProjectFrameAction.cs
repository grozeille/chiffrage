using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Module.Actions
{
    public class RequestNewProjectFrameAction : IEvent
    {
        private readonly int projectId;

        public RequestNewProjectFrameAction(int projectId)
        {
            this.projectId = projectId;
        }

        public int ProjectId
        {
            get { return this.projectId; }
        }
    }
}
