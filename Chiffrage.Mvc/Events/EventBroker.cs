using System;
using System.Collections.Generic;
using System.Threading;
using Common.Logging;

namespace Chiffrage.Mvc.Events
{
    public class EventBroker : IEventBroker
    {
        private readonly Queue<IEvent> eventQueue = new Queue<IEvent>();

        private readonly IList<IEventHandler> subscribers = new List<IEventHandler>();
        private Thread dispatchingThread;

        public IEventHandler[] Subscribers
        {
            set
            {
                lock (this.subscribers)
                {
                    this.subscribers.Clear();
                    foreach (var item in value)
                        this.subscribers.Add(item);
                }
            }
        }

        #region IEventBroker Members

        public void Start()
        {
            if (this.dispatchingThread == null)
                this.dispatchingThread = new Thread(this.DispatchEvents);
            this.dispatchingThread.Start();
        }

        public void Stop()
        {
            this.dispatchingThread.Abort();
        }

        public void Publish<T>(T eventObject) where T : IEvent
        {
            lock (this.eventQueue)
            {
                this.eventQueue.Enqueue(eventObject);
            }
        }

        #endregion

        private void DispatchEvents()
        {
            do
            {
                Thread.Sleep(10);
                IEvent eventObject = null;
                lock (this.eventQueue)
                {
                    if (this.eventQueue.Count > 0)
                        eventObject = this.eventQueue.Dequeue();
                }

                lock (this.subscribers)
                {
                    if (eventObject != null)
                    {
                        foreach (var subscriber in this.subscribers)
                        {
                            var interfaceTypes = subscriber.GetType().GetInterfaces();

                            foreach (var interfaceType in interfaceTypes)
                            {
                                if (interfaceType.Name.Equals("IGenericEventHandler`1"))
                                {
                                    var eventType = interfaceType.GetGenericArguments()[0];
                                    if (eventType.IsInstanceOfType(eventObject))
                                    {
                                        var method = interfaceType.GetMethod("ProcessAction", new[] {eventType});
                                        try
                                        {
                                            method.Invoke(subscriber, new[] {eventObject});
                                        }
                                        catch (Exception ex)
                                        {
                                            LogManager.GetLogger<EventBroker>().ErrorFormat("Unable to dispatch event",
                                                                                            ex);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            } while (true);
        }
    }
}