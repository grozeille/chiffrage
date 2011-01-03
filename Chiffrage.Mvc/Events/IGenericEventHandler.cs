namespace Chiffrage.Mvc.Events
{
    public interface IGenericEventHandler<T> : IEventHandler
        where T : IEvent
    {
        void ProcessAction(T eventObject);
    }
}