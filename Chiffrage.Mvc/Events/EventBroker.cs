﻿using System;
using System.Collections.Generic;
using System.Threading;
using Common.Logging;
using System.Windows.Forms;
using System.Linq;
using System.Reflection;

namespace Chiffrage.Mvc.Events
{
    public class EventBroker: IEventBroker, IDisposable
    {
        private readonly BlockingQueue<object> eventQueue = new BlockingQueue<object>(Int32.MaxValue);

        private Thread dispatchingThread;
        private readonly IList<EventSubscriptionItem> subscribers = new List<EventSubscriptionItem>();

        private ReaderWriterLockSlim subscribersLock = new ReaderWriterLockSlim();

        public SynchronizationContext UISynchronizationContext { get; set; }

        public object[] Subscribers
        {
            set
            {
                subscribersLock.EnterWriteLock();
                
                this.subscribers.Clear();

                foreach (var item in value)
                {
                    SubscribeInternal(item);
                }
                subscribersLock.ExitWriteLock();
            }
        }

        public void Subscribe(object subscriber)
        {
            subscribersLock.EnterWriteLock();
            SubscribeInternal(subscriber);
            subscribersLock.ExitWriteLock();
        }

        private void SubscribeInternal(object subscriber)
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

            // parse each methods with "subscribe" attribute
            foreach(var method in subscriber.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy))
            {
                var subscribreAttribute = method.GetCustomAttributes(typeof(SubscribeAttribute), false).FirstOrDefault() as SubscribeAttribute;
                if(subscribreAttribute != null)
                {
                    // check if the method is an Action<T>
                    if(method.ReturnType != typeof(void) || method.GetParameters().Length != 1)
                    {
                        throw new InvalidOperationException("To subscribe to an event, the method should be an Action<T> (1 parameter, return void): "+method.ToString());
                    }


                    var eventType = method.GetParameters()[0].ParameterType;

                    var threadUI = subscribreAttribute.ThreadUI;

                    var subscriptionItem = new EventSubscriptionItem(eventType, subscriber, method, threadUI);

                    subscribers.Add(subscriptionItem);
                }
            }

            // parse each events to "publish"
            foreach(var eventObject in subscriber.GetType().GetEvents(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy))
            {
                var publishAttribute = eventObject.GetCustomAttributes(typeof(PublishAttribute), false).FirstOrDefault() as PublishAttribute;
                if(publishAttribute != null)
                {
                    // check if the event is an Action<T>
                    var method = eventObject.EventHandlerType.GetMethod("Invoke");

                    if (method.ReturnType != typeof(void) || method.GetParameters().Length != 1)
                    {
                        throw new InvalidOperationException("To publish an event, the method should be an Action<T> (1 parameter, return void): " + method.ToString());
                    }


                    var eventType = method.GetParameters()[0].ParameterType;

                    var eventPublisherType = typeof(EventPublisher<>).MakeGenericType(new Type[] { method.GetParameters()[0].ParameterType });
                    object eventPublisher = Activator.CreateInstance(eventPublisherType, this);

                    var eventPublisherMethod = eventPublisher.GetType().GetMethod("Publish");
                    var eventPublisherDelegate = Delegate.CreateDelegate(eventObject.EventHandlerType, eventPublisher, eventPublisherMethod);

                    eventObject.AddEventHandler(subscriber, eventPublisherDelegate);
                }
            }
        }

        #region IEventBroker Members

        public void Start()
        {
            if (this.dispatchingThread == null)
            {
                this.dispatchingThread = new Thread(this.DispatchEvents);
                this.dispatchingThread.IsBackground = true;
                this.dispatchingThread.Start();
            }
        }

        public void Stop()
        {
            this.dispatchingThread.Abort();
            this.dispatchingThread = null;
        }

        public void Publish(object eventObject)
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
                object eventObject = null;
                if (this.eventQueue.TryDequeue(out eventObject))
                {
                    subscribersLock.EnterReadLock();
                    
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
                                                    var e = (object)args[1];

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

                    subscribersLock.ExitReadLock();
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