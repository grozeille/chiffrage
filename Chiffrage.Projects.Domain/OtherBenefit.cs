namespace Chiffrage.Projects.Domain
{
    public class OtherBenefit
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual double Hours { get; set; }

        public virtual double CostRate { get; set; }

        public virtual double TotalCost
        {
            get { return this.Hours * this.CostRate; }
        }
    }
}