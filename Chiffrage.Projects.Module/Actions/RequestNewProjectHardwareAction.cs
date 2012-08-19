using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Module.Actions
{
    public class RequestNewProjectHardwareAction
    {
        private readonly int projectId;

        public RequestNewProjectHardwareAction(int projectId)
        {
            this.projectId = projectId;
        }

        public int ProjectId
        {
            get { return this.projectId; }
        }
    }
}
