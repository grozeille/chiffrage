using System.Threading;
using Chiffrage.Mvc.Events;
using NUnit.Framework;
using Rhino.Mocks;

namespace Chiffrage.Tests
{
    [TestFixture]
    public class EventBrokerTests
    {
        public class MyEvent : IEvent
        {
        }

        public class MySubEvent : MyEvent
        {
        }

        public abstract class MyEventHandler : IGenericEventHandler<MyEvent>, IGenericEventHandler<MySubEvent>
        {
            #region IGenericEventHandler<MyEvent> Members

            public abstract void ProcessAction(MyEvent action);

            #endregion

            #region IGenericEventHandler<MySubEvent> Members

            public abstract void ProcessAction(MySubEvent action);

            #endregion
        }

        [Test]
        public void TestWithExactType()
        {
            var eventBroker = new EventBroker();

            var eventHandler = MockRepository.GenerateStub<IGenericEventHandler<MyEvent>>();

            eventBroker.Subscribers = new IEventHandler[] {eventHandler};

            eventBroker.Start();

            eventBroker.Publish(new MyEvent());

            Thread.Sleep(3*1000);

            eventHandler.AssertWasCalled(x => x.ProcessAction(Arg<MyEvent>.Is.Anything));
        }

        [Test]
        public void TestWithMultipleType()
        {
            var eventBroker = new EventBroker();

            var eventHandler = MockRepository.GenerateStub<MyEventHandler>();

            eventBroker.Subscribers = new IEventHandler[] {eventHandler};

            eventBroker.Start();

            eventBroker.Publish(new MySubEvent());

            Thread.Sleep(3*1000);

            eventHandler.AssertWasCalled(x => x.ProcessAction(Arg<MyEvent>.Is.Anything));

            eventHandler.AssertWasCalled(x => x.ProcessAction(Arg<MySubEvent>.Is.Anything));
        }

        [Test]
        public void TestWithSubType()
        {
            var eventBroker = new EventBroker();

            var eventHandler = MockRepository.GenerateStub<IGenericEventHandler<MyEvent>>();

            eventBroker.Subscribers = new IEventHandler[] {eventHandler};

            eventBroker.Start();

            eventBroker.Publish(new MySubEvent());

            Thread.Sleep(3*1000);

            eventHandler.AssertWasCalled(x => x.ProcessAction(Arg<MyEvent>.Is.Anything));
        }
    }
}