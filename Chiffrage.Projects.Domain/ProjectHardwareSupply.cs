namespace Chiffrage.Projects.Domain
{
    public class ProjectHardwareSupply
    {
        private ProjectSupply supply;

        public ProjectHardwareSupply()
        {
            this.Supply = new ProjectSupply();
            this.Quantity = 1;
        }

        public virtual int Id { get; set; }

        public virtual int HardwareSupplyId { get; set; }

        public virtual ProjectSupply Supply
        {
            get { return this.supply; }
            set { this.supply = value; }
        }

        public virtual int Quantity { get; set; }

        public virtual string Comment { get; set; }
    }
}