using System;

namespace Chiffrage.Mvc.Events
{
    public interface IEventBroker
    {
        void Publish(object eventObject);

        void Publish(object eventObject, string topic);

        IAsyncResult PublishAndWait(object eventObject);

        IAsyncResult PublishAndWait(object eventObject, string topic);

        void PublishAndExecute(object eventObject, AsyncCallback callback);

        void PublishAndExecute(object eventObject, string topic, AsyncCallback callback);

        void Start();

        void Stop();

        void Subscribe(object subscriber);
    }
}