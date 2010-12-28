namespace Chiffrage.App.Events
{
    public interface IEventBroker
    {
        void Publish<T>(T eventObject) where T : IEvent;

        void Start();

        void Stop();
    }
}