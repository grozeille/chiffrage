﻿using System.ComponentModel;
using Chiffrage.Projects.Domain;

namespace Chiffrage.App.ViewModel
{
    public abstract class AbstractProjectItemViewModel<T> : INotifyPropertyChanged where T : IProjectItem
    {
        protected T item;

        public string Name
        {
            get { return Equals(this.item, default(T)) ? null : this.item.Name; }
        }

        public int Quantity
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.Quantity; }
            set
            {
                if (Equals(this.item, default(T))) return;
                this.item.Quantity = value;
                this.FirePropertyChanged("Quantity");
                this.FirePropertyChanged("TotalPrice");
                this.FirePropertyChanged("TotalStudyDays");
                this.FirePropertyChanged("TotalReferenceDays");
                this.FirePropertyChanged("TotalWorkDays");
                this.FirePropertyChanged("TotalWorkShortNights");
                this.FirePropertyChanged("TotalWorkLongNights");
                this.FirePropertyChanged("TotalTestsDays");
                this.FirePropertyChanged("TotalTestsNights");
            }
        }

        public int ModuleSize
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.ModuleSize; }
        }

        public double CatalogPrice
        {
            get { return this.item.CatalogPrice; }
        }

        public double Price
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.Price; }
            set
            {
                if (Equals(this.item, default(T))) return;
                this.item.Price = value;
                this.FirePropertyChanged("Price");
                this.FirePropertyChanged("TotalPrice");
            }
        }

        public double TotalPrice
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.TotalPrice; }
        }

        public double StudyDays
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.StudyDays; }
        }

        public double TotalStudyDays
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.TotalStudyDays; }
        }

        public double ReferenceDays
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.ReferenceDays; }
        }

        public double TotalReferenceDays
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.TotalReferenceDays; }
        }

        public double CatalogWorkDays
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.CatalogWorkDays; }
        }

        public double CatalogExecutiveWorkDays
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.CatalogExecutiveWorkDays; }
        }

        public double WorkDays
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.WorkDays; }
            set
            {
                if (Equals(this.item, default(T))) return;
                this.item.WorkDays = value;
                this.FirePropertyChanged("WorkDays");
                this.FirePropertyChanged("TotalWorkDays");
            }
        }

        public double ExecutiveWorkDays
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.ExecutiveWorkDays; }
            set
            {
                if (Equals(this.item, default(T))) return;
                this.item.ExecutiveWorkDays = value;
                this.FirePropertyChanged("ExecutiveWorkDays");
                this.FirePropertyChanged("TotalExecutiveWorkDays");
            }
        }

        public double TotalWorkDays
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.TotalWorkDays; }
        }

        public double TotalExecutiveWorkDays
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.TotalExecutiveWorkDays; }
        }

        public double WorkShortNights
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.WorkShortNights; }
            set
            {
                if (Equals(this.item, default(T))) return;
                this.item.WorkShortNights = value;
                this.FirePropertyChanged("WorkShortNights");
                this.FirePropertyChanged("TotalWorkShortNights");
            }
        }

        public double ExecutiveWorkShortNights
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.ExecutiveWorkShortNights; }
            set
            {
                if (Equals(this.item, default(T))) return;
                this.item.ExecutiveWorkShortNights = value;
                this.FirePropertyChanged("ExecutiveWorkShortNights");
                this.FirePropertyChanged("TotalExecutiveWorkShortNights");
            }
        }

        public double TotalWorkShortNights
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.TotalWorkShortNights; }
        }

        public double TotalExecutiveWorkShortNights
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.TotalExecutiveWorkShortNights; }
        }

        public double WorkLongNights
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.WorkLongNights; }
            set
            {
                if (Equals(this.item, default(T))) return;
                this.item.WorkLongNights = value;
                this.FirePropertyChanged("WorkLongNights");
                this.FirePropertyChanged("TotalWorkLongNights");
            }
        }

        public double ExecutiveWorkLongNights
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.ExecutiveWorkLongNights; }
            set
            {
                if (Equals(this.item, default(T))) return;
                this.item.ExecutiveWorkLongNights = value;
                this.FirePropertyChanged("ExecutiveWorkLongNights");
                this.FirePropertyChanged("TotalExecutiveWorkLongNights");
            }
        }

        public double TotalWorkLongNights
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.TotalWorkLongNights; }
        }

        public double TotalExecutiveWorkLongNights
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.TotalExecutiveWorkLongNights; }
        }

        public double CatalogTestsDays
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.TestsDays; }
        }

        public double TestsDays
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.TestsDays; }
            set
            {
                if (Equals(this.item, default(T))) return;
                this.item.TestsDays = value;
                this.FirePropertyChanged("TestsDays");
                this.FirePropertyChanged("TotalTestsDays");
            }
        }

        public double TestsNights
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.TestsNights; }
            set
            {
                if (Equals(this.item, default(T))) return;
                this.item.TestsNights = value;
                this.FirePropertyChanged("TestsNights");
                this.FirePropertyChanged("TotalTestsNights");
            }
        }

        public double TotalTestsDays
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.TotalTestsDays; }
        }

        public double TotalTestsNights
        {
            get { return Equals(this.item, default(T)) ? 0 : this.item.TotalTestsNights; }
        }

        public T Item
        {
            get { return this.item; }
            set { this.item = value; }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private void FirePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}