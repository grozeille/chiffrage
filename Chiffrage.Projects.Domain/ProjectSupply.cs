using Chiffrage.Catalogs.Domain;

namespace Chiffrage.Projects.Domain
{
    public class ProjectSupply : ProjectItem<Supply>
    {
        public ProjectSupply()
        {
        }

        public ProjectSupply(Supply item)
            : base(item)
        {
        }
    }
}