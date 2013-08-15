using System.Collections.Generic;
using System.Linq;

namespace Chiffrage.Catalogs.Domain
{
    public class Hardware
    {
        private IList<HardwareSupply> components;

        public Hardware()
        {
            this.components = new List<HardwareSupply>();
        }

        public virtual IList<HardwareSupply> Components
        {
            get { return this.components; }
            set { this.components = value; }
        }

        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Category { get; set; }


        public virtual double CatalogStudyDays { get; set; }

        public virtual double CatalogReferenceDays { get; set; }

        public virtual double CatalogVerificationDays { get; set; }


        public virtual double CatalogExecutiveWorkDays { get; set; }

        public virtual double CatalogTechnicianWorkDays { get; set; }

        public virtual double CatalogWorkerWorkDays { get; set; }

        public virtual double CatalogTestsDays { get; set; }
    }
}