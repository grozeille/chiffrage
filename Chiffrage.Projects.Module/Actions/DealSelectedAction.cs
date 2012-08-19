using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Module.Actions
{
    public class DealSelectedAction : IEvent
    {
        public DealSelectedAction(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}