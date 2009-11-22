using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Chiffrage.Core;

namespace Chiffrage.Dto
{
    public class ProjectSupplyDto : INotifyPropertyChanged
    {
        public ProjectSupply ProjectSupply { get; set; }

        public string Name
        {
            get { return ProjectSupply == null ? null : (ProjectSupply.Supply == null? null : ProjectSupply.Supply.Name); }
        }

        public int Quantity
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.Quantity; }
            set
            {
                if (ProjectSupply == null) return;
                ProjectSupply.Quantity = value;
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
            get { return ProjectSupply == null ? 0 : (ProjectSupply.Supply == null ? 0 : ProjectSupply.Supply.ModuleSize); }
        }

        public double Price
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.Price; }
            set
            {
                if (ProjectSupply == null) return;
                ProjectSupply.Price = value;
                FirePropertyChanged("Price");
                FirePropertyChanged("TotalPrice");
            }
        }

        public double TotalPrice
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.TotalPrice; }
        }

        public double StudyDays
        {
            get { return ProjectSupply == null ? 0 : (ProjectSupply.Supply == null ? 0 :ProjectSupply.Supply.StudyDays); }
        }

        public double TotalStudyDays
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.TotalStudyDays; }
        }

        public double ReferenceDays
        {
            get { return ProjectSupply == null ? 0 : (ProjectSupply.Supply == null ? 0 :ProjectSupply.Supply.ReferenceDays); }
        }

        public double TotalReferenceDays
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.TotalReferenceDays; }
        }

        public double CatalogWorkDays
        {
            get { return ProjectSupply == null ? 0 : (ProjectSupply.Supply == null ? 0 :ProjectSupply.Supply.WorkDays); }
        }

        public double CatalogExecutiveWorkDays
        {
            get { return ProjectSupply == null ? 0 : (ProjectSupply.Supply == null ? 0 : ProjectSupply.Supply.ExecutiveWorkDays); }
        }

        public double WorkDays
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.WorkDays; }
            set
            {
                if (ProjectSupply == null) return;
                ProjectSupply.WorkDays = value;
                FirePropertyChanged("WorkDays");
                FirePropertyChanged("TotalWorkDays");
            }
        }

        public double ExecutiveWorkDays
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.ExecutiveWorkDays; }
            set
            {
                if (ProjectSupply == null) return;
                ProjectSupply.ExecutiveWorkDays = value;
                FirePropertyChanged("ExecutiveWorkDays");
                FirePropertyChanged("TotalExecutiveWorkDays");
            }
        }

        public double TotalWorkDays
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.TotalWorkDays; }
        }

        public double TotalExecutiveWorkDays
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.TotalExecutiveWorkDays; }
        }

        public double WorkShortNights
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.WorkShortNights; }
            set
            {
                if (ProjectSupply == null) return;
                ProjectSupply.WorkShortNights = value;
                FirePropertyChanged("WorkShortNights");
                FirePropertyChanged("TotalWorkShortNights");
            }
        }

        public double ExecutiveWorkShortNights
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.ExecutiveWorkShortNights; }
            set
            {
                if (ProjectSupply == null) return;
                ProjectSupply.ExecutiveWorkShortNights = value;
                FirePropertyChanged("ExecutiveWorkShortNights");
                FirePropertyChanged("TotalExecutiveWorkShortNights");
            }
        }

        public double TotalWorkShortNights
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.TotalWorkShortNights; }
        }

        public double TotalExecutiveWorkShortNights
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.TotalExecutiveWorkShortNights; }
        }

        public double WorkLongNights
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.WorkLongNights; }
            set
            {
                if (ProjectSupply == null) return;
                ProjectSupply.WorkLongNights = value;
                FirePropertyChanged("WorkLongNights");
                FirePropertyChanged("TotalWorkLongNights");
            }
        }

        public double ExecutiveWorkLongNights
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.ExecutiveWorkLongNights; }
            set
            {
                if (ProjectSupply == null) return;
                ProjectSupply.ExecutiveWorkLongNights = value;
                FirePropertyChanged("ExecutiveWorkLongNights");
                FirePropertyChanged("TotalExecutiveWorkLongNights");
            }
        }

        public double TotalWorkLongNights
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.TotalWorkLongNights; }
        }

        public double TotalExecutiveWorkLongNights
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.TotalExecutiveWorkLongNights; }
        }

        public double CatalogTestsDays
        {
            get { return ProjectSupply == null ? 0 : (ProjectSupply.Supply == null ? 0 :ProjectSupply.Supply.TestsDays); }
        }

        public double TestsDays
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.TestsDays; }
            set
            {
                if (ProjectSupply == null) return;
                ProjectSupply.TestsDays = value;
                FirePropertyChanged("TestsDays");
                FirePropertyChanged("TotalTestsDays");
            }
        }

        public double TestsNights
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.TestsNights; }
            set
            {
                if (ProjectSupply == null) return;
                ProjectSupply.TestsNights = value;
                FirePropertyChanged("TestsNights");
                FirePropertyChanged("TotalTestsNights");
            }
        }

        public double TotalTestsDays
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.TotalTestsDays; }
        }

        public double TotalTestsNights
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.TotalTestsNights; }
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
