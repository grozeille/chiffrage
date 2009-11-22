namespace Chiffrage.Core
{
    public class ProjectSupply
    {
        private Supply supply;

        public ProjectSupply()
        {
            this.Supply = new Supply();
        }

        public virtual int Id { get; set; }

        public virtual Supply Supply
        {
            get { return this.supply; }
            set
            {
                this.supply = value;
                if (this.supply != null)
                    this.Price = this.supply.Price;
                else
                    this.Price = 0;
            }
        }

        public virtual int Quantity { get; set; }

        public virtual double Price { get; set; }

        public virtual double TotalPrice
        {
            get { return this.Price*this.Quantity; }
        }

        public virtual double TotalStudyDays
        {
            get { return this.Supply == null ? 0 : this.Supply.StudyDays*this.Quantity; }
        }

        public virtual double TotalReferenceDays
        {
            get { return this.Supply == null ? 0 : this.Supply.ReferenceDays*this.Quantity; }
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
            get { return this.ExecutiveWorkDays * this.Quantity; }
        }

        public virtual double TotalExecutiveWorkShortNights
        {
            get { return this.ExecutiveWorkShortNights * this.Quantity; }
        }

        public virtual double TotalExecutiveWorkLongNights
        {
            get { return this.ExecutiveWorkLongNights * this.Quantity; }
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
    }
}