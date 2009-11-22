﻿namespace Chiffrage.Core
{
    public class Supply : ISupply
    {
        #region ISupply Members

        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Reference { get; set; }

        public virtual string Category { get; set; }

        public virtual int ModuleSize { get; set; }

        public virtual double Price { get; set; }

        public virtual double StudyDays { get; set; }

        public virtual double ReferenceDays { get; set; }

        public virtual double WorkDays { get; set; }

        public virtual double ExecutiveWorkDays { get; set; }

        public virtual double TestsDays { get; set; }

        public virtual object Clone()
        {
            return MemberwiseClone();
        }

        #endregion
    }
}