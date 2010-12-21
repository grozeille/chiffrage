using Chiffrage.Core;

namespace Chiffrage.Projects.Domain
{
    public class ProjectItem<T> : IProjectItem where T : ICatalogItem
    {
        public ProjectItem()
        {
        }

        public ProjectItem(T item)
        {
            this.Update(item);
        }

        public virtual void Update(T item)
        {
            this.CatalogId = item.Id;
            this.Reference = item.Reference;
            this.Name = item.Name;
            this.Category = item.Category;
            this.ModuleSize = item.ModuleSize;
            this.CatalogPrice = item.CatalogPrice;
            this.StudyDays = item.StudyDays;
            this.ReferenceDays = item.ReferenceDays;
            this.CatalogWorkDays = item.CatalogWorkDays;
            this.CatalogExecutiveWorkDays = item.CatalogExecutiveWorkDays;
            this.CatalogTestsDays = item.CatalogTestsDays;   
        }

        #region IProjectItem Members

        public virtual int CatalogId { get; protected set; }

        public virtual int Id { get; set; }

        public virtual int Quantity { get; set; }

        public virtual double Price { get; set; }

        public virtual double TotalPrice
        {
            get { return this.Price*this.Quantity; }
        }

        public virtual double TotalStudyDays
        {
            get { return this.StudyDays*this.Quantity; }
        }

        public virtual double TotalReferenceDays
        {
            get { return this.ReferenceDays*this.Quantity; }
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
        { get; protected set; }

        public virtual string Reference
        { get; protected set; }

        public virtual string Category
        { get; protected set; }

        public virtual int ModuleSize
        { get; protected set; }

        public virtual double StudyDays
        { get; protected set; }

        public virtual double ReferenceDays
        { get; protected set; }


        public virtual double CatalogPrice
        { get; protected set; }

        public virtual double CatalogWorkDays
        { get; protected set; }

        public virtual double CatalogExecutiveWorkDays
        { get; protected set; }

        public virtual double CatalogTestsDays
        { get; protected set; }

        #endregion
        public virtual object Clone()
        {
            var clone = (ProjectItem<T>)MemberwiseClone();
            return clone;
        }
    }
}