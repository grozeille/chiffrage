namespace Chiffrage.Core
{
    public class ProjectSupply : ProjectItem<Supply>
    {
        public ProjectSupply()
        {
            this.item = new Supply();
        }

        public virtual Supply Supply
        {
            get { return this.Item; } 
            set { this.Item = value; }
        }
    }
}