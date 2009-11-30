namespace Chiffrage.Core
{
    public class ProjectHardware : ProjectItem<Hardware>
    {
        public ProjectHardware()
        {
            this.item = new Hardware();
        }

        public virtual Hardware Hardware
        {
            get { return this.Item; }
            set { this.Item = value; }
        }

        public virtual double Milestone { get; set; }        
    }
}