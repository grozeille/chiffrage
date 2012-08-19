namespace Chiffrage.Mvc.Events
{
    public interface IEventBroker
    {
        void Publish(object eventObject);

        void Start();

        void Stop();

        void Subscribe(object subscriber);
    }
}