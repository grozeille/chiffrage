using System;

namespace Chiffrage.Core
{
    public class Supply : ICloneable
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Reference { get; set; }

        public virtual string Category { get; set; }

        public virtual SupplyCategory SupplyCategory { get; set; }

        public virtual int ModuleSize { get; set; }

        public virtual double Price { get; set; }

        public virtual double StudyDays { get; set; }

        public virtual double ReferenceDays { get; set; }

        public virtual double WorkDays { get; set; }

        public virtual double TestsDays { get; set; }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}