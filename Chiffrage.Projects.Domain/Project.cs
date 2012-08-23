using System;
using System.Collections.Generic;
using System.Linq;

namespace Chiffrage.Projects.Domain
{
    public class Project
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Reference { get; set; }

        public virtual string Comment { get; set; }

        public virtual DateTime StartDate { get; set; }

        public virtual DateTime EndDate { get; set; }

        public virtual IList<ProjectSupply> Supplies { get; set; }

        public virtual IList<ProjectHardware> Hardwares { get; set; }

        public virtual IList<OtherBenefit> OtherBenefits { get; set; }

        public virtual IList<ProjectFrame> Frames { get; set; }

        public virtual double StudyRate { get; set; }

        public virtual double ReferenceRate { get; set; }

        public virtual double WorkDayRate { get; set; }

        public virtual double WorkShortNightsRate { get; set; }

        public virtual double WorkLongNightsRate { get; set; }

        public virtual double ExecutiveWorkDayRate { get; set; }

        public virtual double ExecutiveWorkShortNightsRate { get; set; }

        public virtual double ExecutiveWorkLongNightsRate { get; set; }

        public virtual double TestDayRate { get; set; }

        public virtual double TestNightRate { get; set; }
    }
}