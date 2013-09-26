﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Events
{
    public class ProjectSupplyCreatedEvent : IProjectEvent
    {
        private readonly int projectId;
        private readonly int projectSupplyId;

        public ProjectSupplyCreatedEvent(int projectId, int projectSupplyId)
        {
            this.projectId = projectId;
            this.projectSupplyId = projectSupplyId;
        }

        public int ProjectId { get { return this.projectId; } }
        public int ProjectSupplyId { get { return this.projectSupplyId; } }
    }
}
