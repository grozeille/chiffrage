using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Module.Actions
{
    public class ProjectPasteAction
    {
        public ProjectPasteAction(int dealId)
        {
            this.DealId = dealId;
        }

        public int DealId { get; private set; }
    }
}