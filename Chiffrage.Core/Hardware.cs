using System;
using System.Collections.Generic;
using System.Linq;

namespace Chiffrage.Core
{
    public class Hardware : ISupply
    {
        private IList<Supply> components;

        public Hardware()
        {
            this.components = new List<Supply>();
        }

        public virtual IList<Supply> Components
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
            get { return this.components.Sum((s) => s.ModuleSize); }
        }

        public virtual double Price
        {
            get { return this.components.Sum((s) => s.Price); }
        }

        public virtual double StudyDays
        {
            get { return this.components.Sum((s) => s.StudyDays); }
        }

        public virtual double ReferenceDays
        {
            get { return this.components.Sum((s) => s.ReferenceDays); }
        }

        public virtual double WorkDays
        {
            get { return this.components.Sum((s) => s.WorkDays); }
        }

        public virtual double ExecutiveWorkDays
        {
            get { return this.components.Sum((s) => s.ExecutiveWorkDays); }
        }

        public virtual double TestsDays
        {
            get { return this.components.Sum((s) => s.TestsDays); }
        }


        public virtual object Clone()
        {
            return MemberwiseClone();
        }

        #endregion
    }
}