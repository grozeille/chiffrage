using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Context;
using NHibernate;
using NHibernate.Engine;

namespace Chiffrage.EventStore.Repositories
{
    public class EventStoreSessionContext : CurrentSessionContext
    {
		private static ISession _session;

		protected override ISession Session
		{
			get
			{
                return EventStoreSessionContext._session;
			}
			set
			{
                EventStoreSessionContext._session = value;
			}
		}

        public EventStoreSessionContext(ISessionFactoryImplementor factory)
		{
		}
    }
}
