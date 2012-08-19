using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Domain.Commands
{
    public class UpdateProjectCommand
    {
        private readonly int projectId;

        private readonly string name;

        private readonly string comment;

        private readonly string reference;

        private readonly DateTime startDate;

        private readonly DateTime endDate;

        private readonly double studyRate;

        private readonly double referenceRate;

        private readonly double workDayRate;

        private readonly double workShortNightsRate;

        private readonly double workLongNightsRate;

        private readonly double testDayRate;

        private readonly double testNightRate;

        public UpdateProjectCommand(
            int projectId, 
            string name, 
            string comment, 
            string reference, 
            DateTime startDate, 
            DateTime endDate,
            double studyRate,
            double referenceRate,
            double workDayRate,
            double workShortNightsRate,
            double workLongNightsRate,
            double testDayRate,
            double testNightRate)
        {
            this.projectId = projectId;
            this.name = name;
            this.comment = comment;
            this.reference = reference;
            this.startDate = startDate;
            this.endDate = endDate;
            this.studyRate = studyRate;
            this.referenceRate = referenceRate;
            this.workDayRate = workDayRate;
            this.workShortNightsRate = workShortNightsRate;
            this.workLongNightsRate = workLongNightsRate;
            this.testDayRate = testDayRate;
            this.testNightRate = testNightRate;
        }

        public int ProjectId { get { return this.projectId; } }

        public string Name { get { return this.name; } }

        public string Comment { get { return this.comment; } }

        public string Reference { get { return this.reference; } }

        public DateTime StartDate { get { return this.startDate; } }

        public DateTime EndDate { get { return this.endDate; } }

        public double StudyRate { get { return this.studyRate; } }

        public double ReferenceRate { get { return this.referenceRate; } }

        public double WorkDayRate { get { return this.workDayRate; } }

        public double WorkShortNightsRate { get { return this.workShortNightsRate; } }

        public double WorkLongNightsRate { get { return this.workLongNightsRate; } }

        public double TestDayRate { get { return this.testDayRate; } }

        public double TestNightRate { get { return this.testNightRate; } }
    }
}
