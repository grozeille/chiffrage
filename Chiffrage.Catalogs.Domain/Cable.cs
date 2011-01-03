using Chiffrage.Core;

namespace Chiffrage.Catalogs.Domain
{
    public class Cable : ICatalogItem
    {
        public virtual long Length { get; set; }

        public virtual double PricePerMeter { get; set; }

        #region ICatalogItem Members

        public virtual object Clone()
        {
            return MemberwiseClone();
        }

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Reference { get; set; }
        public virtual string Category { get; set; }
        public virtual int ModuleSize { get; set; }

        public virtual double CatalogPrice
        {
            get { return this.Length*this.PricePerMeter; }
        }

        public virtual double StudyDays { get; set; }
        public virtual double ReferenceDays { get; set; }
        public virtual double CatalogWorkDays { get; set; }
        public virtual double CatalogExecutiveWorkDays { get; set; }

        public virtual double CatalogTestsDays { get; set; }

        #endregion
    }
}