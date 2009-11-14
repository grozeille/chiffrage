using System;
using System.Linq;
using System.Collections.Generic;

namespace Grozeille.Chiffrage.Core
{
    public class Project
    {
        public string Name { get; set; }

        public IList<ProjectSupply> Supplies { get; set; }

        public IList<OtherBenefit> OtherBenefits { get; set; }

        public Project()
        {
            this.Supplies = new List<ProjectSupply>();
            this.OtherBenefits = new List<OtherBenefit>();
        }

        public double TotalSuppliesCost 
        { 
            get
            {
                return this.Supplies.Sum((s) => s.TotalPrice);
            }
        }

        public double TotalStudyDays
        {
            get
            {
                return this.Supplies.Sum((s) => s.TotalStudyDays);
            }
        }

        public double TotalReferenceDays
        {
            get
            {
                return this.Supplies.Sum((s) => s.TotalReferenceDays);
            }
        }

        public double TotalWorkDays
        {
            get
            {
                return this.Supplies.Sum((s) => s.TotalWorkDays);
            }
        }


        public double TotalWorkShortNights
        {
            get
            {
                return this.Supplies.Sum((s) => s.TotalWorkShortNights);
            }
        }

        public double TotalWorkLongNights
        {
            get
            {
                return this.Supplies.Sum((s) => s.TotalWorkLongNights);
            }
        }


        public double TotalTestDays
        {
            get
            {
                return this.Supplies.Sum((s) => s.TotalTestsDays);
            }
        }

        public double TotalTestNights
        {
            get
            {
                return this.Supplies.Sum((s) => s.TotalTestsNights);
            }
        }

        public double StudyRate { get; set; }

        public double ReferenceRate { get; set; }

        public double WorkDayRate { get; set; }

        public double WorkShortNightsRate { get; set; }

        public double WorkLongNightsRate { get; set; }

        public double TestDayRate { get; set; }

        public double TestNightRate { get; set; }

        public double TotalStudyDaysPrice
        {
            get
            {
                return this.TotalStudyDays * this.StudyRate;
            }
        }

        public double TotalReferenceDaysPrice
        {
            get
            {
                return this.TotalReferenceDays * this.ReferenceRate;
            }
        }

        public double TotalWorkDaysPrice
        {
            get { return this.TotalWorkDays + this.WorkDayRate; }
        }

        public double TotalWorkShortNightsPrice
        {
            get { return this.TotalWorkShortNights + this.WorkShortNightsRate; }
        }

        public double TotalWorkLongNightsPrice
        {
            get { return this.TotalWorkLongNights + this.WorkLongNightsRate; }
        }

        public double TotalOtherDays
        {
            get
            {
                return this.OtherBenefits.Sum((o) => o.Days);
            }
        }

        public double TotalDays
        {
            get
            {
                return this.TotalOtherDays + this.TotalReferenceDays + this.TotalStudyDays + this.TotalTestDays +
                       this.TotalTestNights + this.TotalWorkDays + this.TotalWorkShortNights + this.TotalWorkShortNights;
            }
        }

        public double TotalPrice
        {
            get
            {
                return this.TotalSuppliesCost +  this.TotalOtherDaysPrice + this.TotalReferenceDaysPrice + this.TotalStudyDaysPrice + this.TotalTestDayPrice +
                       this.TotalTestNightPrice + this.TotalWorkDaysPrice + this.TotalWorkShortNightsPrice + this.TotalWorkShortNightsPrice;
            }
        }

        public double TotalOtherDaysPrice
        {
            get { return this.OtherBenefits.Sum((o) => o.TotalCost); }
        }

        public double TotalTestDayPrice
        {
            get { return this.TotalTestDays*this.TestDayRate; }
        }

        public double TotalTestNightPrice
        {
            get { return this.TotalTestNights * this.TestNightRate; }
        }
    }
}