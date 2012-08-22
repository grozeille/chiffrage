using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Projects.Domain.Commands
{
    public class UpdateProjectHardwareWorkCommand
    {
        private readonly int projectId;

        private readonly int id;

        private readonly double workDays;

        private readonly double workShortNights;

        private readonly double workLongNights;

        public UpdateProjectHardwareWorkCommand(
            int projectId,
            int id,
            double workDays,
            double workShortNights,
            double workLongNights)
        {
            this.projectId = projectId;
            this.id = id;
            this.workDays = workDays;
            this.workShortNights = workShortNights;
            this.workLongNights = workLongNights;
        }

        public int ProjectId { get { return this.projectId; } }

        public int Id { get { return this.id; } }

        public double WorkDays { get { return this.workDays; } }

        public double WorkShortNights { get { return this.workShortNights; } }

        public double WorkLongNights { get { return this.workLongNights; } }
    }
}
