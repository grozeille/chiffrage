using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Commands
{
	public class CreateNewProjectFrameCommand : IEvent
	{
		private readonly int projectId;

		private readonly int size;

		private readonly int count;

		public CreateNewProjectFrameCommand(int projectId, int size, int count)
		{
			this.projectId = projectId;
			this.size = size;
			this.count = count;
		}

		public int ProjectId { get { return this.projectId; } }

		public int Size { get { return this.size; } }

		public int Count { get { return this.count; } }
	}
}
