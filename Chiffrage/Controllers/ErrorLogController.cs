using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.App.ViewModel;
using Chiffrage.App.Views;
using Chiffrage.Mvc.Events;
using Chiffrage.App.Events;
using Chiffrage.Mvc.Controllers;
using Chiffrage.Catalogs.Domain.Events;
using Chiffrage.Projects.Domain.Events;

namespace Chiffrage.App.Controllers
{
    [Topic(Topics.EVENTS)]
    public class ErrorLogController : IController
    {
        private readonly IErrorLogView view;

        public ErrorLogController(IErrorLogView view)
        {
            this.view = view;
        }

        [Subscribe(Topic = "topic://default")]
        public void ProcessAction(ErrorEvent eventObject)
        {   
            this.AppendLog(eventObject.Exception);  
        }

        private void AppendLog(Exception ex)
        {
            if (ex.InnerException != null)
            {
                this.AppendLog(ex.InnerException);
            }

            this.AppendErrorLog(ex.Message);
        }

        private void AppendErrorLog(string message)
        {
            this.view.AppendLog(new LogItemViewModel
            {
                Date =  DateTime.Now,
                Message = message,
                Severity = SeverityType.Error
            });
        }

        private void AppendInfoLog(string message)
        {
            this.view.AppendLog(new LogItemViewModel
            {
                Date = DateTime.Now,
                Message = message,
                Severity = SeverityType.Info
            });
        }

        [Subscribe]
        public void ProcessAction(CatalogUpdatedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Catalog '{0}' updated successfully", eventObject.CatalogId));
        }

        [Subscribe]
        public void ProcessAction(DealUpdatedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Deal '{0}' updated successfully", eventObject.DealId));
        }

        [Subscribe]
        public void ProcessAction(DealCreatedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Deal '{0}' created successfully", eventObject.DealId));
        }

        [Subscribe]
        public void ProcessAction(CatalogCreatedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Catalog '{0}' created successfully", eventObject.CatalogId));
        }

        [Subscribe]
        public void ProcessAction(SupplyCreatedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Supply '{0}' added successfully", eventObject.SupplyId));
        }

        [Subscribe]
        public void ProcessAction(SupplyUpdatedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Supply '{0}' updated successfully", eventObject.SupplyId));
        }

        [Subscribe]
        public void ProcessAction(ProjectCreatedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Project '{0}' created successfully", eventObject.ProjectId));
        }

        [Subscribe]
        public void ProcessAction(ProjectUpdatedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Project '{0}' updated successfully", eventObject.ProjectId));
        }

        [Subscribe(Topic = Topics.EVENTS)]
        public void ProcessAction(Object eventObject)
        {
            this.AppendInfoLog(string.Format("Message '{0}'", eventObject.ToString()));
        }
    }
}
