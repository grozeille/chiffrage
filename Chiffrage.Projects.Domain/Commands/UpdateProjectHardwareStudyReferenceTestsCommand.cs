using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Projects.Domain.Commands
{
    public class UpdateProjectHardwareStudyReferenceTestsCommand
    {
        private readonly int projectId;

        private readonly int id;

        private readonly double studyDays;

        private readonly double referenceDays;

        private readonly double testsDays;

        private readonly double testsNights;

        public UpdateProjectHardwareStudyReferenceTestsCommand(
            int projectId,
            int id,
            double studyDays,
            double referenceDays,
            double testsDays,
            double testsNights)
        {
            this.projectId = projectId;
            this.id = id;
            this.studyDays = studyDays;
            this.referenceDays = referenceDays;
            this.testsDays = testsDays;
            this.testsNights = testsNights;
        }

        public int ProjectId { get { return this.projectId; } }

        public int Id { get { return this.id; } }

        public double StudyDays { get { return this.studyDays; } }

        public double ReferenceDays { get { return this.referenceDays; } }

        public double TestsDays { get { return this.testsDays; } }

        public double TestsNights { get { return this.testsNights; } }
    }
}
