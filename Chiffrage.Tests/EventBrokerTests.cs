using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;
using NUnit.Framework;
using Chiffrage.App.Events;
using Rhino.Mocks;
using System.Threading;

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
            public abstract void ProcessAction(MyEvent action);

            public abstract void ProcessAction(MySubEvent action);
        }

        [Test]
        public void TestWithExactType()
        {
            var eventBroker = new EventBroker();

            var eventHandler = MockRepository.GenerateStub<IGenericEventHandler<MyEvent>>();

            eventBroker.Subscribers = new IEventHandler[]{ eventHandler};

            eventBroker.Start();

            eventBroker.Publish(new MyEvent());

            Thread.Sleep(3*1000);

            eventHandler.AssertWasCalled(x => x.ProcessAction(Arg<MyEvent>.Is.Anything));
        }

        [Test]
        public void TestWithSubType()
        {
            var eventBroker = new EventBroker();

            var eventHandler = MockRepository.GenerateStub<IGenericEventHandler<MyEvent>>();

            eventBroker.Subscribers = new IEventHandler[] { eventHandler };

            eventBroker.Start();

            eventBroker.Publish(new MySubEvent());

            Thread.Sleep(3 * 1000);

            eventHandler.AssertWasCalled(x => x.ProcessAction(Arg<MyEvent>.Is.Anything));
        }

        [Test]
        public void TestWithMultipleType()
        {
            var eventBroker = new EventBroker();

            var eventHandler = MockRepository.GenerateStub<MyEventHandler>();

            eventBroker.Subscribers = new IEventHandler[] { eventHandler };

            eventBroker.Start();

            eventBroker.Publish(new MySubEvent());

            Thread.Sleep(3 * 1000);

            eventHandler.AssertWasCalled(x => x.ProcessAction(Arg<MyEvent>.Is.Anything));

            eventHandler.AssertWasCalled(x => x.ProcessAction(Arg<MySubEvent>.Is.Anything));
        }
    }
}
