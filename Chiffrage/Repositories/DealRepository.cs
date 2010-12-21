using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Core;
using Chiffrage.Projects.Domain;
using Chiffrage.Projects.Domain.Repositories;
using NHibernate;

namespace Chiffrage.Repositories
{
    public class DealRepository : IDealRepository
    {
        public ISession Session { get; set; }

        public IList<Deal> FindAll()
        {
            this.Session.Clear();
            return this.Session.CreateCriteria(typeof (Deal)).List<Deal>();
        }

        public void Save(Deal deal)
        {
            Session.BeginTransaction();
            try
            {
                Session.SaveOrUpdateCopy(deal);
                Session.Transaction.Commit();
            }
            catch(Exception ex)
            {
                Session.Transaction.Rollback();
            }
        }

        public Deal FindById(int dealId)
        {
            return this.Session.Get<Deal>(dealId);
        }
    }
}
