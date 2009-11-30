namespace Chiffrage.Core
{
    public class ProjectItem<T> : IProjectItem where T : ICatalogItem
    {
        protected T item;

        public ProjectItem()
        {
            this.item = default(T);
        }

        public virtual T Item
        {
            get { return this.item; }
            set
            {
                this.item = value;
                if (!Equals(this.item, default(T)))
                    this.Price = this.item.CatalogPrice;
                else
                    this.Price = 0;
            }
        }

        #region IProjectItem Members

        public virtual int Id { get; set; }

        public virtual int Quantity { get; set; }

        public virtual double Price { get; set; }

        public virtual double TotalPrice
        {
            get { return this.Price*this.Quantity; }
        }

        public virtual double TotalStudyDays
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.StudyDays*this.Quantity; }
        }

        public virtual double TotalReferenceDays
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.ReferenceDays*this.Quantity; }
        }

        public virtual double WorkDays { get; set; }

        public virtual double WorkShortNights { get; set; }

        public virtual double WorkLongNights { get; set; }

        public virtual double TotalWorkDays
        {
            get { return this.WorkDays*this.Quantity; }
        }

        public virtual double TotalWorkShortNights
        {
            get { return this.WorkShortNights*this.Quantity; }
        }

        public virtual double TotalWorkLongNights
        {
            get { return this.WorkLongNights*this.Quantity; }
        }

        public virtual double ExecutiveWorkDays { get; set; }

        public virtual double ExecutiveWorkShortNights { get; set; }

        public virtual double ExecutiveWorkLongNights { get; set; }

        public virtual double TotalExecutiveWorkDays
        {
            get { return this.ExecutiveWorkDays*this.Quantity; }
        }

        public virtual double TotalExecutiveWorkShortNights
        {
            get { return this.ExecutiveWorkShortNights*this.Quantity; }
        }

        public virtual double TotalExecutiveWorkLongNights
        {
            get { return this.ExecutiveWorkLongNights*this.Quantity; }
        }

        public virtual double TestsDays { get; set; }

        public virtual double TestsNights { get; set; }

        public virtual double TotalTestsDays
        {
            get { return this.TestsDays*this.Quantity; }
        }

        public virtual double TotalTestsNights
        {
            get { return this.TestsNights*this.Quantity; }
        }

        public virtual string Name
        {
            get { return Equals(this.item, default(T)) ? string.Empty : this.item.Name; }
        }

        public virtual string Reference
        {
            get { return Equals(this.item, default(T)) ? string.Empty : this.item.Reference; }
        }

        public virtual string Category
        {
            get { return Equals(this.item, default(T)) ? string.Empty : this.item.Category; }
        }

        public virtual int ModuleSize
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.ModuleSize; }
        }

        public virtual double StudyDays
        {
            get { return Equals(this.item, default(T)) ? 0.0 : this.item.StudyDays; }
        }

        public virtual double ReferenceDays
        {
            get { return Equals(this.item, default(T)) ? 0.0 : this.item.ReferenceDays; }
        }

        public virtual object Clone()
        {
            var clone = (ProjectItem<T>) MemberwiseClone();
            clone.item = (T) this.item.Clone();
            return clone;
        }

        public virtual double CatalogPrice
        {
            get { return Equals(this.item, default(T)) ? 0.0 : this.item.CatalogPrice; }
        }

        public virtual double CatalogWorkDays
        {
            get { return Equals(this.item, default(T)) ? 0.0 : this.item.CatalogWorkDays; }
        }

        public virtual double CatalogExecutiveWorkDays
        {
            get { return Equals(this.item, default(T)) ? 0.0 : this.item.CatalogExecutiveWorkDays; }
        }

        public virtual double CatalogTestsDays
        {
            get { return Equals(this.item, default(T)) ? 0.0 : this.item.CatalogTestsDays; }
        }

        #endregion
    }
}