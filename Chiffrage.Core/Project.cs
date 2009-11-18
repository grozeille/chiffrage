using System.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Chiffrage.Core
{
    public class Project// : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private string reference;
        private string comment;
        private DateTime startDate;
        private DateTime endDate;

        private IList<OtherBenefit> otherBenefits = new List<OtherBenefit>();

        private IList<ProjectSupply> supplies = new List<ProjectSupply>();

        public virtual int Id
        {
            get { return id; }
            set { id = value; FirePropertyChanged("Id");}
        }
        
        public virtual string Name
        {
            get { return name; }
            set { name = value; FirePropertyChanged("Name"); }
        }

        public virtual string Reference
        {
            get { return reference; }
            set { reference = value; FirePropertyChanged("Reference"); }
        }
        
        public virtual string Comment
        {
            get { return comment; }
            set { comment = value; FirePropertyChanged("Comment"); }
        }


        public virtual DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; FirePropertyChanged("StartDate"); }
        }
        
        public virtual DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; FirePropertyChanged("EndDate"); }
        }

        public virtual IList<ProjectSupply> Supplies
        {
            get { return supplies; }
            set { supplies = value; }
        }

        public virtual IList<OtherBenefit> OtherBenefits
        {
            get { return otherBenefits; }
            set { otherBenefits = value; }
        }

        public virtual double TotalSuppliesCost 
        { 
            get
            {
                return this.Supplies.Sum((s) => s.TotalPrice);
            }
        }

        public virtual double TotalStudyDays
        {
            get
            {
                return this.Supplies.Sum((s) => s.TotalStudyDays);
            }
        }

        public virtual double TotalReferenceDays
        {
            get
            {
                return this.Supplies.Sum((s) => s.TotalReferenceDays);
            }
        }

        public virtual double TotalWorkDays
        {
            get
            {
                return this.Supplies.Sum((s) => s.TotalWorkDays);
            }
        }


        public virtual double TotalWorkShortNights
        {
            get
            {
                return this.Supplies.Sum((s) => s.TotalWorkShortNights);
            }
        }

        public virtual double TotalWorkLongNights
        {
            get
            {
                return this.Supplies.Sum((s) => s.TotalWorkLongNights);
            }
        }


        public virtual double TotalTestDays
        {
            get
            {
                return this.Supplies.Sum((s) => s.TotalTestsDays);
            }
        }

        public virtual double TotalTestNights
        {
            get
            {
                return this.Supplies.Sum((s) => s.TotalTestsNights);
            }
        }

        public virtual double StudyRate { get; set; }

        public virtual double ReferenceRate { get; set; }

        public virtual double WorkDayRate { get; set; }

        public virtual double WorkShortNightsRate { get; set; }

        public virtual double WorkLongNightsRate { get; set; }

        public virtual double TestDayRate { get; set; }

        public virtual double TestNightRate { get; set; }

        public virtual double TotalStudyDaysPrice
        {
            get
            {
                return this.TotalStudyDays * this.StudyRate;
            }
        }

        public virtual double TotalReferenceDaysPrice
        {
            get
            {
                return this.TotalReferenceDays * this.ReferenceRate;
            }
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
            get
            {
                return this.OtherBenefits.Sum((o) => o.Days);
            }
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
                return this.TotalSuppliesCost +  this.TotalOtherDaysPrice + this.TotalReferenceDaysPrice + this.TotalStudyDaysPrice + this.TotalTestDayPrice +
                       this.TotalTestNightPrice + this.TotalWorkDaysPrice + this.TotalWorkShortNightsPrice + this.TotalWorkShortNightsPrice;
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
            get { return this.TotalTestNights * this.TestNightRate; }
        }

        #region INotifyPropertyChanged Members

        public virtual event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private void FirePropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}