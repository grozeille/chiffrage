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
    public class ProjectRepository : IProjectRepository
    {
        public ISession Session { get; set; }

        public IList<Project> FindAll()
        {
            this.Session.Clear();
            return this.Session.CreateCriteria(typeof(Project)).List<Project>();
        }

        public void Save(Project project)
        {
            Session.BeginTransaction();
            try
            {
                Session.SaveOrUpdateCopy(project);
                Session.Transaction.Commit();
            }
            catch(Exception ex)
            {
                Session.Transaction.Rollback();
            }
        }

        public Project FindById(int projectId)
        {
            return this.Session.Get<Project>(projectId);
        }
    }
}
