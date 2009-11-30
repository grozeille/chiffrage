namespace Chiffrage.Core
{
    public class Supply : ICatalogItem
    {
        #region ISupply Members

        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Reference { get; set; }

        public virtual string Category { get; set; }

        public virtual int ModuleSize { get; set; }

        public virtual double CatalogPrice { get; set; }

        public virtual double StudyDays { get; set; }

        public virtual double ReferenceDays { get; set; }

        public virtual double CatalogWorkDays { get; set; }

        public virtual double CatalogExecutiveWorkDays { get; set; }

        public virtual double CatalogTestsDays { get; set; }

        public virtual object Clone()
        {
            return MemberwiseClone();
        }

        #endregion
    }
}