using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Chiffrage.Core
{
    /// <summary>
    /// TODO : mauvais calul car ne tiens pas en compte les hardwares
    /// </summary>
    public class Project : INotifyPropertyChanged
    {
        private string comment;
        private DateTime endDate;
        private int id;
        private string name;
        private IList<OtherBenefit> otherBenefits = new List<OtherBenefit>();
        private string reference;
        private double referenceRate;
        private DateTime startDate;


        private double studyRate;
        private IList<ProjectSupply> supplies = new List<ProjectSupply>();
        private IList<ProjectHardware> hardwares = new List<ProjectHardware>();
        private double testDayRate;
        private double testNightRate;
        private double workDayRate;
        private double workLongNightsRate;
        private double workShortNightsRate;

        public virtual int Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
                this.FirePropertyChanged("Id");
            }
        }

        public virtual string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                this.FirePropertyChanged("Name");
            }
        }

        public virtual string Reference
        {
            get { return this.reference; }
            set
            {
                this.reference = value;
                this.FirePropertyChanged("Reference");
            }
        }

        public virtual string Comment
        {
            get { return this.comment; }
            set
            {
                this.comment = value;
                this.FirePropertyChanged("Comment");
            }
        }


        public virtual DateTime StartDate
        {
            get { return this.startDate; }
            set
            {
                this.startDate = value;
                this.FirePropertyChanged("StartDate");
            }
        }

        public virtual DateTime EndDate
        {
            get { return this.endDate; }
            set
            {
                this.endDate = value;
                this.FirePropertyChanged("EndDate");
            }
        }

        public virtual IList<ProjectSupply> Supplies
        {
            get { return this.supplies; }
            set
            {
                this.supplies = value;
                this.FirePropertyChanged("Supplies");
            }
        }

        public virtual IList<ProjectHardware> Hardwares
        {
            get { return this.hardwares; }
            set
            {
                this.hardwares = value;
                this.FirePropertyChanged("Hardwares");
            }
        }

        public virtual IList<OtherBenefit> OtherBenefits
        {
            get { return this.otherBenefits; }
            set
            {
                this.otherBenefits = value;
                this.FirePropertyChanged("OtherBenefits");
            }
        }

        public virtual double TotalSuppliesCost
        {
            get { return this.Supplies.Sum((s) => s.TotalPrice); }
        }

        public virtual double TotalStudyDays
        {
            get { return this.Supplies.Sum((s) => s.TotalStudyDays); }
        }

        public virtual double TotalReferenceDays
        {
            get { return this.Supplies.Sum((s) => s.TotalReferenceDays); }
        }

        public virtual double TotalWorkDays
        {
            get { return this.Supplies.Sum((s) => s.TotalWorkDays); }
        }


        public virtual double TotalWorkShortNights
        {
            get { return this.Supplies.Sum((s) => s.TotalWorkShortNights); }
        }

        public virtual double TotalWorkLongNights
        {
            get { return this.Supplies.Sum((s) => s.TotalWorkLongNights); }
        }


        public virtual double TotalTestDays
        {
            get { return this.Supplies.Sum((s) => s.TotalTestsDays); }
        }

        public virtual double TotalTestNights
        {
            get { return this.Supplies.Sum((s) => s.TotalTestsNights); }
        }


        public virtual double StudyRate
        {
            get { return this.studyRate; }
            set
            {
                this.studyRate = value;
                this.FirePropertyChanged("StudyRate");
                this.FirePropertyChanged("TotalStudyDaysPrice");
                this.FirePropertyChanged("TotalPrice");
            }
        }

        public virtual double ReferenceRate
        {
            get { return this.referenceRate; }
            set
            {
                this.referenceRate = value;
                this.FirePropertyChanged("ReferenceRate");
                this.FirePropertyChanged("TotalReferenceDaysPrice");
                this.FirePropertyChanged("TotalPrice");
            }
        }


        public virtual double WorkDayRate
        {
            get { return this.workDayRate; }
            set
            {
                this.workDayRate = value;
                this.FirePropertyChanged("WorkDayRate");
                this.FirePropertyChanged("TotalWorkDaysPrice");
                this.FirePropertyChanged("TotalPrice");
            }
        }


        public virtual double WorkShortNightsRate
        {
            get { return this.workShortNightsRate; }
            set
            {
                this.workShortNightsRate = value;
                this.FirePropertyChanged("WorkShortNightsRate");
                this.FirePropertyChanged("TotalWorkShortNightsPrice");
                this.FirePropertyChanged("TotalPrice");
            }
        }


        public virtual double WorkLongNightsRate
        {
            get { return this.workLongNightsRate; }
            set
            {
                this.workLongNightsRate = value;
                this.FirePropertyChanged("WorkLongNightsRate");
                this.FirePropertyChanged("TotalWorkLongNightsPrice");
                this.FirePropertyChanged("TotalPrice");
            }
        }


        public virtual double TestDayRate
        {
            get { return this.testDayRate; }
            set
            {
                this.testDayRate = value;
                this.FirePropertyChanged("TestDayRate");
                this.FirePropertyChanged("TotalTestDayPrice");
                this.FirePropertyChanged("TotalPrice");
            }
        }


        public virtual double TestNightRate
        {
            get { return this.testNightRate; }
            set
            {
                this.testNightRate = value;
                this.FirePropertyChanged("TestNightRate");
                this.FirePropertyChanged("TotalTestNightPrice");
                this.FirePropertyChanged("TotalPrice");
            }
        }

        public virtual double TotalStudyDaysPrice
        {
            get { return this.TotalStudyDays*this.StudyRate; }
        }

        public virtual double TotalReferenceDaysPrice
        {
            get { return this.TotalReferenceDays*this.ReferenceRate; }
        }

        public virtual double TotalWorkDaysPrice
        {
            get { return this.TotalWorkDays + this.WorkDayRate; }
        }

        public virtual double TotalWorkShortNightsPrice
        {
            get { return this.TotalWorkShortNights + this.WorkShortNightsRate; }
        }

        public virtual double TotalWorkLongNightsPrice
        {
            get { return this.TotalWorkLongNights + this.WorkLongNightsRate; }
        }

        public virtual double TotalOtherDays
        {
            get { return this.OtherBenefits.Sum((o) => o.Days); }
        }

        public virtual double TotalDays
        {
            get
            {
                return this.TotalOtherDays + this.TotalReferenceDays + this.TotalStudyDays + this.TotalTestDays +
                       this.TotalTestNights + this.TotalWorkDays + this.TotalWorkShortNights + this.TotalWorkShortNights;
            }
        }

        public virtual double TotalPrice
        {
            get
            {
                return this.TotalSuppliesCost + this.TotalOtherDaysPrice + this.TotalReferenceDaysPrice +
                       this.TotalStudyDaysPrice + this.TotalTestDayPrice +
                       this.TotalTestNightPrice + this.TotalWorkDaysPrice + this.TotalWorkShortNightsPrice +
                       this.TotalWorkShortNightsPrice;
            }
        }

        public virtual double TotalOtherDaysPrice
        {
            get { return this.OtherBenefits.Sum((o) => o.TotalCost); }
        }

        public virtual double TotalTestDayPrice
        {
            get { return this.TotalTestDays*this.TestDayRate; }
        }

        public virtual double TotalTestNightPrice
        {
            get { return this.TotalTestNights*this.TestNightRate; }
        }

        #region INotifyPropertyChanged Members

        public virtual event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private void FirePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}