using System;
using System.Collections.Generic;
using System.Threading;
using Common.Logging;
using System.Windows.Forms;
using System.Linq;
using System.Reflection;

namespace Chiffrage.Mvc.Events
{
    public class EventBroker : IEventBroker, IDisposable
    {
        private readonly BlockingQueue<IEvent> eventQueue = new BlockingQueue<IEvent>(Int32.MaxValue);

        private Thread dispatchingThread;
        private readonly IList<EventSubscriptionItem> subscribers = new List<EventSubscriptionItem>();

        private ReaderWriterLock subscribersLock = new ReaderWriterLock();

        public SynchronizationContext UISynchronizationContext { get; set; }

        public IEventHandler[] Subscribers
        {
            set
            {
                subscribersLock.AcquireWriterLock(-1);
                
                this.subscribers.Clear();

                foreach (var item in value)
                {
                    SubscribeInternal(item);
                }
                subscribersLock.ReleaseWriterLock();
            }
        }

        public void Subscribe(IEventHandler subscriber)
        {
            subscribersLock.AcquireWriterLock(-1);
            SubscribeInternal(subscriber);
            subscribersLock.ReleaseWriterLock();
        }

        private void SubscribeInternal(IEventHandler subscriber)
        {
            var interfaceTypes = subscriber.GetType().GetInterfaces();

            foreach (var interfaceType in interfaceTypes)
            {
                if (interfaceType.Name.Equals("IGenericEventHandler`1") || interfaceType.Name.Equals("IGenericEventHandlerUI`1"))
                {
                    var eventType = interfaceType.GetGenericArguments()[0];

                    var threadUI = interfaceType.Name.Equals("IGenericEventHandlerUI`1");

                    var subscriptionItem = new EventSubscriptionItem(eventType, subscriber, interfaceType.GetMethod("ProcessAction", new[] { eventType }), threadUI);

                    subscribers.Add(subscriptionItem);
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
                    subscribersLock.AcquireReaderLock(-1);
                    
                    foreach (var subscriber in this.subscribers)
                    {
                        if (subscriber.EventType.IsInstanceOfType(eventObject))
                        {
                            //ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                            //    {
                                    try
                                    {
                                        if (subscriber.ThreadUI)
                                        {
                                            this.UISynchronizationContext.Post((o) => 
                                                {
                                                    var args = (object[])o;
                                                    var s = (EventSubscriptionItem)args[0];
                                                    var e = (IEvent)args[1];

                                                    s.Method.Invoke(s.EventHandler, new[] { e });

                                                }, new object[]{ subscriber, eventObject});
                                        }
                                        else
                                        {
                                            subscriber.Method.Invoke(subscriber.EventHandler, new[] { eventObject });
                                        }
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
            } while (true);
        }

        public void Dispose()
        {
            if (this.dispatchingThread != null)
                this.Stop();
        }

        public EventBroker()
        {
            this.UISynchronizationContext = WindowsFormsSynchronizationContext.Current;
        }
    }
}