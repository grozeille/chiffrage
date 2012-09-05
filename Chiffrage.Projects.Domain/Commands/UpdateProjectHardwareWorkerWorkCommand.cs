using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Projects.Domain.Commands
{
    public class UpdateProjectHardwareWorkerWorkCommand
    {
        private readonly int projectId;

        private readonly int id;

        private readonly double workerWorkDays;

        private readonly double workerWorkShortNights;

        private readonly double workerWorkLongNights;

        public UpdateProjectHardwareWorkerWorkCommand(
            int projectId,
            int id,
            double workDays,
            double workShortNights,
            double workLongNights)
        {
            this.projectId = projectId;
            this.id = id;
            this.workerWorkDays = workDays;
            this.workerWorkShortNights = workShortNights;
            this.workerWorkLongNights = workLongNights;
        }

        public int ProjectId { get { return this.projectId; } }

        public int Id { get { return this.id; } }

        public double WorkerWorkDays { get { return this.workerWorkDays; } }

        public double WorkerWorkShortNights { get { return this.workerWorkShortNights; } }

        public double WorkerWorkLongNights { get { return this.workerWorkLongNights; } }
    }
}
