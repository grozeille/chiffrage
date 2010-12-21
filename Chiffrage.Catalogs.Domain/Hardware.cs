using System;
using System.Collections.Generic;
using System.Linq;
using Chiffrage.Core;

namespace Chiffrage.Catalogs.Domain
{
    public class Hardware : ICatalogItem
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

        #region ISupply Members

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Reference { get; set; }
        public virtual string Category { get; set; }

        public virtual int ModuleSize
        {
            get { return this.components.Sum((s) => (s.Supply != null ? s.Supply.ModuleSize*s.Quantity : 0)); }
        }

        public virtual double CatalogPrice
        {
            get { return this.components.Sum((s) => (s.Supply != null ? s.Supply.CatalogPrice * s.Quantity : 0)); }
        }

        public virtual double StudyDays
        {
            get { return this.components.Sum((s) => (s.Supply != null ? s.Supply.StudyDays * s.Quantity : 0)); }
        }

        public virtual double ReferenceDays
        {
            get { return this.components.Sum((s) => (s.Supply != null ? s.Supply.ReferenceDays * s.Quantity : 0)); }
        }

        public virtual double CatalogWorkDays
        {
            get { return this.components.Sum((s) => (s.Supply != null ? s.Supply.CatalogWorkDays * s.Quantity : 0)); }
        }

        public virtual double CatalogExecutiveWorkDays
        {
            get { return this.components.Sum((s) => (s.Supply != null ? s.Supply.CatalogExecutiveWorkDays * s.Quantity : 0)); }
        }

        public virtual double CatalogTestsDays
        {
            get { return this.components.Sum((s) => (s.Supply != null ? s.Supply.CatalogTestsDays * s.Quantity : 0)); }
        }


        public virtual object Clone()
        {
            var h = (Hardware)MemberwiseClone();
            h.components = new List<HardwareSupply>();
            foreach(var item in this.components)
                h.components.Add(item.Clone() as HardwareSupply);
            return h;
        }

        #endregion
    }
}