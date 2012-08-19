using System.Threading;
using Chiffrage.Mvc.Events;
using NUnit.Framework;
using Moq;

namespace Chiffrage.Mvc.Tests
{
    [TestFixture]
    public class EventBrokerTests
    {
        public class MyEvent
        {
        }

        public class MySubEvent : MyEvent
        {
        }

        public abstract class MyEventHandler: IEventHandler<MyEvent>, IEventHandler<MySubEvent>
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

            var eventHandler = new Mock<IEventHandler<MyEvent>>();

            eventBroker.Subscribers = new object[] {eventHandler.Object};

            eventBroker.Start();

            eventBroker.Publish(new MyEvent());

            Thread.Sleep(3*1000);

            eventHandler.Verify(x => x.ProcessAction(It.IsAny<MyEvent>()));
        }

        [Test]
        public void TestWithMultipleType()
        {
            var eventBroker = new EventBroker();

            var eventHandler = new Mock<MyEventHandler>();

            eventBroker.Subscribers = new object[] {eventHandler.Object};

            eventBroker.Start();

            eventBroker.Publish(new MySubEvent());

            Thread.Sleep(3*1000);

            eventHandler.Verify(x => x.ProcessAction(It.IsAny<MyEvent>()));

            eventHandler.Verify(x => x.ProcessAction(It.IsAny<MySubEvent>()));            
        }

        [Test]
        public void TestWithSubType()
        {
            var eventBroker = new EventBroker();

            var eventHandler = new Mock<IEventHandler<MyEvent>>();

            eventBroker.Subscribers = new object[] { eventHandler.Object };

            eventBroker.Start();

            eventBroker.Publish(new MySubEvent());

            Thread.Sleep(3*1000);

            eventHandler.Verify(x => x.ProcessAction(It.IsAny<MyEvent>()));
        }
    }
}