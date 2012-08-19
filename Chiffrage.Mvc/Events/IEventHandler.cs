namespace Chiffrage.Mvc.Events
{
    public interface IEventHandler<T>
    {
        void ProcessAction(T eventObject);
    }
}