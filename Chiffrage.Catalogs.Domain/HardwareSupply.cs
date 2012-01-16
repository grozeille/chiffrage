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