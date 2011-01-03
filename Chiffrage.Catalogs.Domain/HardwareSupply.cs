namespace Chiffrage.Catalogs.Domain
{
    public class HardwareSupply // : ICatalogItem
    {
        private Supply supply;

        public HardwareSupply()
        {
            this.Supply = new Supply();
            this.Quantity = 1;
        }

        public virtual int Id { get; set; }

        /*
        public virtual string Name
        {
            get { return this.supply == null ? null : this.Supply.Name; }
        }

        public virtual string Reference
        {
            get { return this.supply == null ? null : this.Supply.Reference; }
        }

        public virtual string Category
        {
            get { return this.supply == null ? null : this.Supply.Category; }
        }

        public virtual int ModuleSize
        {
            get { return this.supply == null ? 0 : this.Supply.ModuleSize; }
        }

        public virtual double CatalogPrice
        {
            get { return this.supply == null ? 0.0 : this.Supply.CatalogPrice; }
        }

        public virtual double StudyDays
        {
            get { return this.supply == null ? 0.0: this.Supply.StudyDays; }
        }

        public virtual double ReferenceDays
        {
            get { return this.supply == null ? 0.0 : this.Supply.ReferenceDays; }
        }

        public virtual double CatalogWorkDays
        {
            get { return this.supply == null ? 0.0 : this.Supply.CatalogWorkDays; }
        }

        public virtual double CatalogExecutiveWorkDays
        {
            get { return this.supply == null ? 0.0 : this.Supply.CatalogExecutiveWorkDays; }
        }

        public virtual double CatalogTestsDays
        {
            get { return this.supply == null ? 0.0 : this.Supply.CatalogTestsDays; }
        }
        */

        public virtual Supply Supply
        {
            get { return this.supply; }
            set { this.supply = value; }
        }

        public virtual int Quantity { get; set; }

        public virtual object Clone()
        {
            var hardwareSupply = (HardwareSupply) MemberwiseClone();
            hardwareSupply.supply = (Supply) this.supply.Clone();
            return hardwareSupply;
        }
    }
}