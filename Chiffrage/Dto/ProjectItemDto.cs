using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Chiffrage.Core;

namespace Chiffrage.Dto
{
    public class ProjectItemDto<T> : INotifyPropertyChanged where T : IProjectItem
    {
        protected T item;

        public string Name
        {
            get { return object.Equals(item, default(T)) ? null : item.Name; }
        }

        public int Quantity
        {
            get { return object.Equals(item, default(T)) ? 0 : item.Quantity; }
            set
            {
                if (object.Equals(item, default(T))) return;
                item.Quantity = value;
                FirePropertyChanged("Quantity");
                FirePropertyChanged("TotalPrice");
                FirePropertyChanged("TotalStudyDays");
                FirePropertyChanged("TotalReferenceDays");
                FirePropertyChanged("TotalWorkDays");
                FirePropertyChanged("TotalWorkShortNights");
                FirePropertyChanged("TotalWorkLongNights");
                FirePropertyChanged("TotalTestsDays");
                FirePropertyChanged("TotalTestsNights");
            }
        }

        public int ModuleSize
        {
            get { return object.Equals(item, default(T)) ? 0 : item.ModuleSize; }
        }

        public double CatalogPrice
        {
            get { return this.item.CatalogPrice; }
        }

        public double Price
        {
            get { return object.Equals(item, default(T)) ? 0 : item.Price; }
            set
            {
                if (object.Equals(item, default(T))) return;
                item.Price = value;
                FirePropertyChanged("Price");
                FirePropertyChanged("TotalPrice");
            }
        }

        public double TotalPrice
        {
            get { return object.Equals(item, default(T)) ? 0 : item.TotalPrice; }
        }

        public double StudyDays
        {
            get { return object.Equals(item, default(T)) ? 0 : item.StudyDays; }
        }

        public double TotalStudyDays
        {
            get { return object.Equals(item, default(T)) ? 0 : item.TotalStudyDays; }
        }

        public double ReferenceDays
        {
            get { return object.Equals(item, default(T)) ? 0 : item.ReferenceDays; }
        }

        public double TotalReferenceDays
        {
            get { return object.Equals(item, default(T)) ? 0 : item.TotalReferenceDays; }
        }

        public double CatalogWorkDays
        {
            get { return object.Equals(item, default(T)) ? 0 : item.CatalogWorkDays; }
        }

        public double CatalogExecutiveWorkDays
        {
            get { return object.Equals(item, default(T)) ? 0 : item.CatalogExecutiveWorkDays; }
        }

        public double WorkDays
        {
            get { return object.Equals(item, default(T)) ? 0 : item.WorkDays; }
            set
            {
                if (object.Equals(item, default(T))) return;
                item.WorkDays = value;
                FirePropertyChanged("WorkDays");
                FirePropertyChanged("TotalWorkDays");
            }
        }

        public double ExecutiveWorkDays
        {
            get { return object.Equals(item, default(T)) ? 0 : item.ExecutiveWorkDays; }
            set
            {
                if (object.Equals(item, default(T))) return;
                item.ExecutiveWorkDays = value;
                FirePropertyChanged("ExecutiveWorkDays");
                FirePropertyChanged("TotalExecutiveWorkDays");
            }
        }

        public double TotalWorkDays
        {
            get { return object.Equals(item, default(T)) ? 0 : item.TotalWorkDays; }
        }

        public double TotalExecutiveWorkDays
        {
            get { return object.Equals(item, default(T)) ? 0 : item.TotalExecutiveWorkDays; }
        }

        public double WorkShortNights
        {
            get { return object.Equals(item, default(T)) ? 0 : item.WorkShortNights; }
            set
            {
                if (object.Equals(item, default(T))) return;
                item.WorkShortNights = value;
                FirePropertyChanged("WorkShortNights");
                FirePropertyChanged("TotalWorkShortNights");
            }
        }

        public double ExecutiveWorkShortNights
        {
            get { return object.Equals(item, default(T)) ? 0 : item.ExecutiveWorkShortNights; }
            set
            {
                if (object.Equals(item, default(T))) return;
                item.ExecutiveWorkShortNights = value;
                FirePropertyChanged("ExecutiveWorkShortNights");
                FirePropertyChanged("TotalExecutiveWorkShortNights");
            }
        }

        public double TotalWorkShortNights
        {
            get { return object.Equals(item, default(T)) ? 0 : item.TotalWorkShortNights; }
        }

        public double TotalExecutiveWorkShortNights
        {
            get { return object.Equals(item, default(T)) ? 0 : item.TotalExecutiveWorkShortNights; }
        }

        public double WorkLongNights
        {
            get { return object.Equals(item, default(T)) ? 0 : item.WorkLongNights; }
            set
            {
                if (object.Equals(item, default(T))) return;
                item.WorkLongNights = value;
                FirePropertyChanged("WorkLongNights");
                FirePropertyChanged("TotalWorkLongNights");
            }
        }

        public double ExecutiveWorkLongNights
        {
            get { return object.Equals(item, default(T)) ? 0 : item.ExecutiveWorkLongNights; }
            set
            {
                if (object.Equals(item, default(T))) return;
                item.ExecutiveWorkLongNights = value;
                FirePropertyChanged("ExecutiveWorkLongNights");
                FirePropertyChanged("TotalExecutiveWorkLongNights");
            }
        }

        public double TotalWorkLongNights
        {
            get { return object.Equals(item, default(T)) ? 0 : item.TotalWorkLongNights; }
        }

        public double TotalExecutiveWorkLongNights
        {
            get { return object.Equals(item, default(T)) ? 0 : item.TotalExecutiveWorkLongNights; }
        }

        public double CatalogTestsDays
        {
            get { return object.Equals(item, default(T)) ? 0 : item.TestsDays; }
        }

        public double TestsDays
        {
            get { return object.Equals(item, default(T)) ? 0 : item.TestsDays; }
            set
            {
                if (object.Equals(item, default(T))) return;
                item.TestsDays = value;
                FirePropertyChanged("TestsDays");
                FirePropertyChanged("TotalTestsDays");
            }
        }

        public double TestsNights
        {
            get { return object.Equals(item, default(T)) ? 0 : item.TestsNights; }
            set
            {
                if (object.Equals(item, default(T))) return;
                item.TestsNights = value;
                FirePropertyChanged("TestsNights");
                FirePropertyChanged("TotalTestsNights");
            }
        }

        public double TotalTestsDays
        {
            get { return object.Equals(item, default(T)) ? 0 : item.TotalTestsDays; }
        }

        public double TotalTestsNights
        {
            get { return object.Equals(item, default(T)) ? 0 : item.TotalTestsNights; }
        }

        public T Item
        {
            get { return this.item; }
            set { this.item = value; }
        }

        #region INotifyPropertyChanged Members

        private void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
