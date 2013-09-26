using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Projects.Domain;

namespace Chiffrage.Projects.Module.ViewModel
{
    public class ProjectViewModel
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Reference { get; set; }

        public virtual string Comment { get; set; }

        public virtual DateTime StartDate { get; set; }

        public virtual DateTime EndDate { get; set; }

        public virtual double TotalDays { get; set; }

        public virtual double TotalPrice { get; set; }

        public virtual int TotalModules { get; set; }

        public virtual int ModulesNotInFrame { get; set; }

        public virtual IList<ProjectTask> Tasks { get; set; }

        public IList<OtherBenefit> OtherBenefits { get; set; }
    }
}
