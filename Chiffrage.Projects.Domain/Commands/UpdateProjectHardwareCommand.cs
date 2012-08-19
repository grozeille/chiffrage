using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Projects.Domain.Commands
{
    public class UpdateProjectHardwareCommand
    {
        private readonly int projectId;

        private readonly int id;

        private readonly int quantity;

        private readonly string name;

        private readonly double studyDays;

        private readonly double referenceDays;

        private readonly double workDays;

        private readonly double executiveWorkDays;

        private readonly double testsDays;

        public UpdateProjectHardwareCommand(
            int projectId,
            int id,
            int quantity,
            string name,
            double studyDays,
            double referenceDays,
            double workDays,
            double executiveWorkDays,
            double testsDays)
        {
            this.projectId = projectId;
            this.id = id;
            this.quantity = quantity;
            this.name = name;
            this.studyDays = studyDays;
            this.referenceDays = referenceDays;
            this.workDays = workDays;
            this.executiveWorkDays = executiveWorkDays;
            this.testsDays = testsDays;
        }

        public int ProjectId { get { return this.projectId; } }

        public int Id { get { return this.id; } }

        public string Name { get { return this.name; } }

        public double StudyDays { get { return this.studyDays; } }

        public double ReferenceDays { get { return this.referenceDays; } }

        public double WorkDays { get { return this.workDays; } }

        public double ExecutiveWorkDays { get { return this.executiveWorkDays; } }

        public double TestsDays { get { return this.testsDays; } }
    }
}
