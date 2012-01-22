using System;
using System.Collections.Generic;
using System.Linq;

namespace Chiffrage.Projects.Domain
{
    /// <summary>
    /// TODO : mauvais calul car ne tiens pas en compte les hardwares
    /// </summary>
    public class Project
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Reference { get; set; }

        public virtual string Comment { get; set; }


        public virtual DateTime StartDate { get; set; }

        public virtual DateTime EndDate { get; set; }

        public virtual IList<ProjectSupply> Supplies { get; set; }

        public virtual IList<ProjectHardware> Hardwares { get; set; }

        public virtual IList<OtherBenefit> OtherBenefits { get; set; }

        //public virtual double TotalSuppliesCost
        //{
        //    get { return this.Supplies.Sum((s) => s.TotalPrice); }
        //}

        //public virtual double TotalStudyDays
        //{
        //    get { return this.Supplies.Sum((s) => s.TotalStudyDays); }
        //}

        //public virtual double TotalReferenceDays
        //{
        //    get { return this.Supplies.Sum((s) => s.TotalReferenceDays); }
        //}

        //public virtual double TotalWorkDays
        //{
        //    get { return this.Supplies.Sum((s) => s.TotalWorkDays); }
        //}


        //public virtual double TotalWorkShortNights
        //{
        //    get { return this.Supplies.Sum((s) => s.TotalWorkShortNights); }
        //}

        //public virtual double TotalWorkLongNights
        //{
        //    get { return this.Supplies.Sum((s) => s.TotalWorkLongNights); }
        //}


        //public virtual double TotalTestDays
        //{
        //    get { return this.Supplies.Sum((s) => s.TotalTestsDays); }
        //}

        //public virtual double TotalTestNights
        //{
        //    get { return this.Supplies.Sum((s) => s.TotalTestsNights); }
        //}


        public virtual double StudyRate { get; set; }

        public virtual double ReferenceRate { get; set; }


        public virtual double WorkDayRate { get; set; }


        public virtual double WorkShortNightsRate { get; set; }


        public virtual double WorkLongNightsRate { get; set; }


        public virtual double TestDayRate { get; set; }


        public virtual double TestNightRate { get; set; }

        //public virtual double TotalStudyDaysPrice
        //{
        //    get { return this.TotalStudyDays*this.StudyRate; }
        //}

        //public virtual double TotalReferenceDaysPrice
        //{
        //    get { return this.TotalReferenceDays*this.ReferenceRate; }
        //}

        //public virtual double TotalWorkDaysPrice
        //{
        //    get { return this.TotalWorkDays + this.WorkDayRate; }
        //}

        //public virtual double TotalWorkShortNightsPrice
        //{
        //    get { return this.TotalWorkShortNights + this.WorkShortNightsRate; }
        //}

        //public virtual double TotalWorkLongNightsPrice
        //{
        //    get { return this.TotalWorkLongNights + this.WorkLongNightsRate; }
        //}

        //public virtual double TotalOtherDays
        //{
        //    get { return this.OtherBenefits.Sum((o) => o.Days); }
        //}

        //public virtual double TotalDays
        //{
        //    get
        //    {
        //        return this.TotalOtherDays + this.TotalReferenceDays + this.TotalStudyDays + this.TotalTestDays +
        //               this.TotalTestNights + this.TotalWorkDays + this.TotalWorkShortNights + this.TotalWorkShortNights;
        //    }
        //}

        //public virtual double TotalPrice
        //{
        //    get
        //    {
        //        return this.TotalSuppliesCost + this.TotalOtherDaysPrice + this.TotalReferenceDaysPrice +
        //               this.TotalStudyDaysPrice + this.TotalTestDayPrice +
        //               this.TotalTestNightPrice + this.TotalWorkDaysPrice + this.TotalWorkShortNightsPrice +
        //               this.TotalWorkShortNightsPrice;
        //    }
        //}

        //public virtual double TotalOtherDaysPrice
        //{
        //    get { return this.OtherBenefits.Sum((o) => o.TotalCost); }
        //}

        //public virtual double TotalTestDayPrice
        //{
        //    get { return this.TotalTestDays*this.TestDayRate; }
        //}

        //public virtual double TotalTestNightPrice
        //{
        //    get { return this.TotalTestNights*this.TestNightRate; }
        //}
    }
}