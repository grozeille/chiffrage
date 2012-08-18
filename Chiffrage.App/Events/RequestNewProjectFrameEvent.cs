﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.App.Events
{
    public class RequestNewProjectFrameEvent : IEvent
    {
        private readonly int projectId;

        public RequestNewProjectFrameEvent(int projectId)
        {
            this.projectId = projectId;
        }

        public int ProjectId
        {
            get { return this.projectId; }
        }
    }
}