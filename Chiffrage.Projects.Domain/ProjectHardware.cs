using Chiffrage.Catalogs.Domain;
using System.Collections.Generic;

namespace Chiffrage.Projects.Domain
{
    public class ProjectHardware
    {
        private IList<ProjectHardwareSupply> components;

        public ProjectHardware()
        {
            this.components = new List<ProjectHardwareSupply>();
        }

        public virtual IList<ProjectHardwareSupply> Components
        {
            get { return this.components; }
            set { this.components = value; }
        }

        public virtual int Id { get; set; }

        public virtual int CatalogId { get; set; }

        public virtual int HardwareId { get; set; }

        public virtual int Quantity { get; set; }

        public virtual string Name { get; set; }

        public virtual string Reference { get; set; }

        public virtual string Category { get; set; }

        public virtual double CatalogStudyDays { get; set; }

        public virtual double CatalogReferenceDays { get; set; }

        public virtual double CatalogTestsDays { get; set; }

        public virtual double CatalogWorkDays { get; set; }

        public virtual double CatalogExecutiveWorkDays { get; set; }

        public virtual double StudyDays { get; set; }

        public virtual double ReferenceDays { get; set; }

        public virtual double TestsDays { get; set; }

        public virtual double WorkDays { get; set; }

        public virtual double WorkShortNights { get; set; }

        public virtual double WorkLongNights { get; set; }

        public virtual double ExecutiveWorkDays { get; set; }

        public virtual double ExecutiveWorkShortNights { get; set; }

        public virtual double ExecutiveWorkLongNights { get; set; }

    }
}