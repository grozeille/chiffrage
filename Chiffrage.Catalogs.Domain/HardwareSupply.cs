namespace Chiffrage.Catalogs.Domain
{
    public class HardwareSupply
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

        public virtual string Comment { get; set; }
    }
}