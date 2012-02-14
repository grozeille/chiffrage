using System;
using System.Collections.Generic;
using System.Threading;
using Common.Logging;
using System.Windows.Forms;
using System.Reactive.Concurrency;
using System.Linq;

namespace Chiffrage.Mvc.Events
{
    public class EventBroker : IEventBroker, IDisposable
    {
        private readonly BlockingQueue<IEvent> eventQueue = new BlockingQueue<IEvent>(Int32.MaxValue);

        private readonly IList<IEventHandler> subscribers = new List<IEventHandler>();
        private Thread dispatchingThread;
        private readonly IDictionary<Type, IList<EventSubscriptionItem>> subscribersCache = new Dictionary<Type, IList<EventSubscriptionItem>>();

        public IEventHandler[] Subscribers
        {
            set
            {
                lock (this.subscribers)
                {
                    this.subscribersCache.Clear();

                    this.subscribers.Clear();
                    foreach (var item in value)
                    {
                        this.subscribers.Add(item);

                        foreach (var subscriber in this.subscribers)
                        {
                            var interfaceTypes = subscriber.GetType().GetInterfaces();

                            foreach (var interfaceType in interfaceTypes)
                            {
                                if (interfaceType.Name.Equals("IGenericEventHandler`1"))
                                {
                                    var eventType = interfaceType.GetGenericArguments()[0];
                                    if (!this.subscribersCache.ContainsKey(eventType))
                                    {
                                        this.subscribersCache.Add(eventType, new List<EventSubscriptionItem>());
                                    }

                                    var subscriptionItem = new EventSubscriptionItem(subscriber, interfaceType.GetMethod("ProcessAction", new[] { eventType }));                                    

                                    if (!this.subscribersCache[eventType].Where(x => x.EventHandler == subscriber).Any())
                                    {
                                        this.subscribersCache[eventType].Add(subscriptionItem);
                                    }
                                }
                            }
                        }
                    }
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
            this.dispatchingThread = null;
        }

        public void Publish<T>(T eventObject) where T : IEvent
        {
            this.eventQueue.Enqueue(eventObject);

            if (this.dispatchingThread == null)
                this.Start();
        }

        #endregion

        private void DispatchEvents()
        {
            do
            {
                IEvent eventObject = null;
                if (this.eventQueue.TryDequeue(out eventObject))
                {
                    lock (this.subscribers)
                    {
                        foreach (var type in this.subscribersCache.Keys)
                        {
                            if (type.IsInstanceOfType(eventObject))
                            {
                                foreach (var subscriber in this.subscribersCache[type])
                                {
                                    //ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                                    //    {
                                            try
                                            {
                                                subscriber.Method.Invoke(subscriber.EventHandler, new[] { eventObject });
                                                //subscriber.Dispatch(eventObject);
                                            }
                                            catch (Exception ex)
                                            {
                                                LogManager.GetLogger<EventBroker>().ErrorFormat("Unable to dispatch event", ex);

                                                this.Publish(new ErrorEvent(ex));
                                            }
                                        //}));
                                }
                            }
                        }
                    }
                }
            } while (true);
        }

        public void Dispose()
        {
            if (this.dispatchingThread != null)
                this.Stop();
        }
    }
}