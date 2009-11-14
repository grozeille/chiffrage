using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Grozeille.Chiffrage.Core;

namespace Chiffrage.Dto
{
    public class ProjectSupplyDto : INotifyPropertyChanged
    {
        public ProjectSupply ProjectSupply { get; set; }

        public string Name 
        {
            get { return ProjectSupply == null ? null : ProjectSupply.Supply.Name; }
        }

        public int Quantity
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.Quantity; }
            set 
            { 
                if(ProjectSupply == null) return;
                ProjectSupply.Quantity = value;
                FirePropertyChanged("Quantity");
            }
        }

        public int ModuleSize
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.Supply.ModuleSize; }
        }

        public double Price
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.Price; }
            set
            {
                if (ProjectSupply == null) return;
                ProjectSupply.Price = value;
                FirePropertyChanged("Price");
            }
        }

        public double TotalPrice
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.TotalPrice; }
        }

        public double StudyDays
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.Supply.StudyDays; }
        }

        public double TotalStudyDays
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.TotalStudyDays; }
        }

        public double ReferenceDays
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.Supply.ReferenceDays; }
        }

        public double TotalReferenceDays
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.TotalReferenceDays; }
        }

        public double CatalogWorkDays
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.Supply.WorkDays; }
        }

        public double WorkDays
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.WorkDays; }
            set
            {
                if (ProjectSupply == null) return;
                ProjectSupply.WorkDays = value;
                FirePropertyChanged("WorkDays");
            }
        }

        public double TotalWorkDays
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.TotalWorkDays; }            
        }

        public double WorkShortNights
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.WorkShortNights; }
            set
            {
                if (ProjectSupply == null) return;
                ProjectSupply.WorkShortNights = value;
                FirePropertyChanged("WorkShortNights");
            }
        }

        public double TotalWorkShortNights
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.TotalWorkShortNights; }
        }

        public double WorkLongNights
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.WorkLongNights; }
            set
            {
                if (ProjectSupply == null) return;
                ProjectSupply.WorkLongNights = value;
                FirePropertyChanged("WorkLongNights");
            }
        }

        public double TotalWorkLongNights
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.TotalWorkLongNights; }
        }

        public double CatalogTestsDays
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.Supply.TestsDays; }
        }

        public double TestsDays
        {
            get { return ProjectSupply == null ? 0 : ProjectSupply.TestsDays; }
            set
            {
                if (ProjectSupply == null) return;
                ProjectSupply.TestsDays = value;
                FirePropertyChanged("TestsDays");
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
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
