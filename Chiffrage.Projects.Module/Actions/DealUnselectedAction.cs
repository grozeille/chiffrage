using Chiffrage.Mvc.Events;

namespace Chiffrage.Projects.Module.Actions
{
    public class DealUnselectedAction : IEvent
    {
        public DealUnselectedAction(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}