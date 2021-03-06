﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Commands
{
    public class RefreshProjectTasksCommand
    {
        private readonly int projectId;

        public RefreshProjectTasksCommand(int projectId)
        {
            this.projectId = projectId;
        }

        public int ProjectId { get { return this.projectId; } }
    }
}
