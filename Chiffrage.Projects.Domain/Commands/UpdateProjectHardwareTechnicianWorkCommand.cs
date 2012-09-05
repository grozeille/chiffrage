using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Projects.Domain.Commands
{
    public class UpdateProjectHardwareTechnicianWorkCommand
    {
        private readonly int projectId;

        private readonly int id;

        private readonly double technicianWorkDays;

        private readonly double technicianWorkShortNights;

        private readonly double technicianWorkLongNights;

        public UpdateProjectHardwareTechnicianWorkCommand(
            int projectId,
            int id,
            double workDays,
            double workShortNights,
            double workLongNights)
        {
            this.projectId = projectId;
            this.id = id;
            this.technicianWorkDays = workDays;
            this.technicianWorkShortNights = workShortNights;
            this.technicianWorkLongNights = workLongNights;
        }

        public int ProjectId { get { return this.projectId; } }

        public int Id { get { return this.id; } }

        public double TechnicianWorkDays { get { return this.technicianWorkDays; } }

        public double TechnicianWorkShortNights { get { return this.technicianWorkShortNights; } }

        public double TechnicianWorkLongNights { get { return this.technicianWorkLongNights; } }
    }
}
