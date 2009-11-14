using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grozeille.Chiffrage.Core
{
    public class ProjectSupply
    {
        private Supply supply;
        public Supply Supply
        {
            get { return supply; }
            set
            {
                supply = value;
                if(supply != null)
                    this.Price = this.supply.Price;
                else
                    this.Price = 0;
            }
        }

        public int Quantity { get; set; }

        public ProjectSupply()
        {
            this.Supply = new Supply();            
        }

        public double Price { get; set; }

        public double TotalPrice
        {
            get
            {
                return this.Price*this.Quantity;
            }
        }

        public double TotalStudyDays
        {
            get
            {
                return this.Supply.StudyDays*this.Quantity;
            }
        }

        public double TotalReferenceDays
        {
            get
            {
                return this.Supply.ReferenceDays * this.Quantity;
            }
        }

        public double WorkDays { get; set; }

        public double WorkShortNights { get; set; }

        public double WorkLongNights { get; set; }

        public double TotalWorkDays
        {
            get
            {
                return this.WorkDays*this.Quantity; 
            }
        }

        public double TotalWorkShortNights
        {
            get
            {
                return this.WorkShortNights * this.Quantity;
            }
        }

        public double TotalWorkLongNights
        {
            get
            {
                return this.WorkLongNights * this.Quantity;
            }
        }

        public double TestsDays { get; set; }

        public double TestsNights { get; set; }

        public double TotalTestsDays
        {
            get
            {
                return this.TestsDays*this.Quantity;
            }
        }

        public double TotalTestsNights
        {
            get
            {
                return this.TestsNights * this.Quantity;
            }
        }
    }
}
