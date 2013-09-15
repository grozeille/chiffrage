using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace Chiffrage.EventStore.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ISessionFactory sessionFactory;

        public EventRepository(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
            SessionManager.OpenSessionIfRequired(this.sessionFactory);
        }

        public void Save(EventObject eventObject)
        {
            SessionManager.OpenSessionIfRequired(this.sessionFactory).Save(eventObject);
        }
    }
}
