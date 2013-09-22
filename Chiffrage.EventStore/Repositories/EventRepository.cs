﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;

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
            var session = SessionManager.OpenSessionIfRequired(this.sessionFactory);
            using (var transaction = session.BeginTransaction())
            {
                session.Save(eventObject);
                session.Transaction.Commit();
            }
        }

        public IList<EventObject> FindFromOtherSession(string sessionId, int fromId)
        {
            var session = SessionManager.OpenSessionIfRequired(this.sessionFactory);

            return session.QueryOver<EventObject>().Where(x => x.Id > fromId).WhereNot(x => sessionId == x.SessionId).OrderBy(x => x.Id).Asc.List();
        }

        public void CleanOldEvents(DateTime fromDate)
        {
            throw new NotImplementedException();
        }
    }
}
