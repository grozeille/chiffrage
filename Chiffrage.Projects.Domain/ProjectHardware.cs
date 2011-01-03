using Chiffrage.Catalogs.Domain;

namespace Chiffrage.Projects.Domain
{
    public class ProjectHardware : ProjectItem<Hardware>
    {
        public ProjectHardware()
        {
        }

        public ProjectHardware(Hardware item)
            : base(item)
        {
        }

        public virtual double Milestone { get; set; }
    }
}