namespace Chiffrage.Mvc.Events
{
    public interface IEventBroker
    {
        void Publish<T>(T eventObject) where T : IEvent;

        void Start();

        void Stop();
    }
}