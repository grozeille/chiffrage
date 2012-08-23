using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Projects.Domain.Commands
{
    public class UpdateProjectHardwareExecutiveWorkCommand
    {
        private readonly int projectId;

        private readonly int id;

        private readonly double executiveWorkDays;

        private readonly double executiveWorkShortNights;

        private readonly double executiveWorkLongNights;

        public UpdateProjectHardwareExecutiveWorkCommand(
            int projectId,
            int id,
            double workDays,
            double workShortNights,
            double workLongNights)
        {
            this.projectId = projectId;
            this.id = id;
            this.executiveWorkDays = workDays;
            this.executiveWorkShortNights = workShortNights;
            this.executiveWorkLongNights = workLongNights;
        }

        public int ProjectId { get { return this.projectId; } }

        public int Id { get { return this.id; } }

        public double ExecutiveWorkDays { get { return this.executiveWorkDays; } }

        public double ExecutiveWorkShortNights { get { return this.executiveWorkShortNights; } }

        public double ExecutiveWorkLongNights { get { return this.executiveWorkLongNights; } }
    }
}
