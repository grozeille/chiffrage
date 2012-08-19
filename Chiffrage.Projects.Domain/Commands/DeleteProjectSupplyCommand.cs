﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Commands
{
    public class DeleteProjectSupplyCommand
    {
        private readonly int projectId;

        private readonly int projectSupplyId;

        public DeleteProjectSupplyCommand(int projectId, int projectSupplyId)
        {
            this.projectId = projectId;
            this.projectSupplyId = projectSupplyId;
        }

        public int ProjectSupplyId { get { return this.projectSupplyId; } }

        public int ProjectId { get { return this.projectId; } }
    }
}
