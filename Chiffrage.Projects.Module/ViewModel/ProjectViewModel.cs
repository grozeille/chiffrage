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

        public virtual double StudyRate { get; set; }

        public virtual double ReferenceRate { get; set; }

        public virtual double WorkDayRate { get; set; }

        public virtual double WorkShortNightsRate { get; set; }

        public virtual double WorkLongNightsRate { get; set; }

        public virtual double TestDayRate { get; set; }

        public virtual double TestNightRate { get; set; }

        public virtual int TotalDays { get; set; }

        public virtual double TotalPrice { get; set; }

        public virtual int TotalModules { get; set; }

        public virtual int ModulesNotInFrame { get; set; }
    }
}
