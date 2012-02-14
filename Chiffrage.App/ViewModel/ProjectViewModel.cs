using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.App.ViewModel
{
    public class ProjectViewModel
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Reference { get; set; }

        public virtual string Comment { get; set; }

        public virtual DateTime StartDate { get; set; }

        public virtual DateTime EndDate { get; set; }

        public virtual string StudyRate { get; set; }

        public virtual string ReferenceRate { get; set; }

        public virtual string WorkDayRate { get; set; }

        public virtual string WorkShortNightsRate { get; set; }

        public virtual string WorkLongNightsRate { get; set; }

        public virtual string TestDayRate { get; set; }

        public virtual string TestNightRate { get; set; }

        public virtual string TotalDays { get; set; }

        public virtual string TotalPrice { get; set; }

        public virtual int TotalModules { get; set; }

        public virtual int ModulesNotInFrame { get; set; }
    }
}
