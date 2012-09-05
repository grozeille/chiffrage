using System;
using System.Collections.Generic;
using System.Threading;
using Common.Logging;
using System.Windows.Forms;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Chiffrage.Mvc.Events
{
    public class EventBroker: IEventBroker, IDisposable
    {
        private readonly BlockingQueue<Message> eventQueue = new BlockingQueue<Message>(Int32.MaxValue);

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

        private Action<object, object> CreateDispatchDelegate(Type subscriberType, MethodInfo methodInfo)
        {
            var dynamicMethod = new System.Reflection.Emit.DynamicMethod(
                        methodInfo.Name,
                        typeof(void),
                        new Type[] { typeof(object), typeof(object) });

            var il = dynamicMethod.GetILGenerator();
            il.Emit(System.Reflection.Emit.OpCodes.Nop);
            il.Emit(System.Reflection.Emit.OpCodes.Ldarg_0);
            il.Emit(System.Reflection.Emit.OpCodes.Isinst, subscriberType);
            il.Emit(System.Reflection.Emit.OpCodes.Ldarg_1);
            il.Emit(System.Reflection.Emit.OpCodes.Isinst, methodInfo.GetParameters()[0].ParameterType);
            il.Emit(System.Reflection.Emit.OpCodes.Callvirt, methodInfo);
            il.Emit(System.Reflection.Emit.OpCodes.Nop);
            il.Emit(System.Reflection.Emit.OpCodes.Ret);

            var methodDelegate = (Action<object, object>)dynamicMethod.CreateDelegate(typeof(Action<object, object>));

            return methodDelegate;
        }

        private void SubscribeInternal(object subscriber)
        {
            var interfaceTypes = subscriber.GetType().GetInterfaces();

            foreach (var interfaceType in interfaceTypes)
            {
                if (interfaceType.Name.Equals("IGenericEventHandler`1") || interfaceType.Name.Equals("IGenericEventHandlerUI`1"))
                {
                    var eventType = interfaceType.GetGenericArguments()[0];

                    var method = interfaceType.GetMethod("ProcessAction", new[] { eventType });

                    var methodDelegate = CreateDispatchDelegate(subscriber.GetType(), method);

                    var threadUI = interfaceType.Name.Equals("IGenericEventHandlerUI`1") ? SubscriptionMode.UIThread : SubscriptionMode.Default;

                    var subscriptionItem = new EventSubscriptionItem(eventType, subscriber, methodDelegate, threadUI);

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

                    var methodDelegate = CreateDispatchDelegate(subscriber.GetType(), method);

                    var eventType = method.GetParameters()[0].ParameterType;

                    var threadUI = subscribreAttribute.SubscriptionMode;

                    var subscriptionItem = new EventSubscriptionItem(eventType, subscriber, methodDelegate, threadUI);

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
                this.dispatchingThread.Priority = ThreadPriority.Highest;
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
            this.InternalPublish(new Message { Body = eventObject });
        }

        public IAsyncResult PublishAndWait(object eventObject)
        {
            var result = new MessageAsyncResult();
            var message = new Message { Body = eventObject, AsyncResult = result };

            this.InternalPublish(message);

            return result;
        }

        public void PublishAndExecute(object eventObject, AsyncCallback callback)
        {
            var result = new MessageAsyncResult();
            var message = new Message { Body = eventObject, AsyncResult = result, AsyncCallback = callback };

            this.InternalPublish(message);
        }

        private void InternalPublish(Message message)
        {
            this.eventQueue.Enqueue(message);

            if (this.dispatchingThread == null)
                this.Start();
        }

        #endregion

        private void DispatchEvents()
        {
            do
            {
                Message message = null;
                
                if (this.eventQueue.TryDequeue(out message))
                {
                    subscribersLock.EnterReadLock();
                    
                    foreach (var subscriber in this.subscribers)
                    {
                        if (subscriber.EventType.IsInstanceOfType(message.Body))
                        {
                            try
                            {
                                if (subscriber.SubscriptionMode == SubscriptionMode.UIThread)
                                {
                                    this.UISynchronizationContext.Post((o) => 
                                        {
                                            var args = (object[])o;
                                            var s = (EventSubscriptionItem)args[0];
                                            var m = (Message)args[1];

                                            //s.Method.Invoke(s.EventHandler, new[] { m.Body });
                                            s.Method(s.EventHandler, m.Body);

                                            if (m.AsyncResult != null)
                                            {
                                                m.AsyncResult.ManualResetEvent.Set();

                                                if (m.AsyncCallback != null)
                                                {
                                                    m.AsyncCallback(m.AsyncResult);
                                                }
                                            }

                                        }, new object[]{ subscriber, message});
                                }
                                else if (subscriber.SubscriptionMode == SubscriptionMode.Default)
                                {
                                    //subscriber.Method.Invoke(subscriber.EventHandler, new[] { message.Body });
                                    subscriber.Method(subscriber.EventHandler, message.Body);

                                    if (message.AsyncResult != null)
                                    {
                                        message.AsyncResult.ManualResetEvent.Set();
                                        if (message.AsyncCallback != null)
                                        {
                                            message.AsyncCallback(message.AsyncResult);
                                        }
                                    }
                                }
                                else if (subscriber.SubscriptionMode == SubscriptionMode.NewThread)
                                {
                                    ThreadPool.QueueUserWorkItem((o) =>
                                        {
                                            var args = (object[])o;
                                            var s = (EventSubscriptionItem)args[0];
                                            var m = (Message)args[1];

                                            //s.Method.Invoke(s.EventHandler, new[] { m.Body });
                                            s.Method(s.EventHandler, m.Body);

                                            if (m.AsyncResult != null)
                                            {
                                                m.AsyncResult.ManualResetEvent.Set();

                                                if (m.AsyncCallback != null)
                                                {
                                                    m.AsyncCallback(m.AsyncResult);
                                                }
                                            }

                                        }, new object[] { subscriber, message });
                                }
                            }
                            catch (Exception ex)
                            {
                                LogManager.GetLogger<EventBroker>().ErrorFormat("Unable to dispatch event", ex);

                                this.Publish(new ErrorEvent(ex));
                            }
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
            if (this.UISynchronizationContext == null)
            {
                AsyncOperationManager.CreateOperation(null);
                this.UISynchronizationContext = AsyncOperationManager.SynchronizationContext;
            }
        }
    }
}