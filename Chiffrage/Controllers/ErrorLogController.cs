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

        [Subscribe(Topic = Topics.DEFAULT)]
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
            return;
            this.view.AppendLog(new LogItemViewModel
            {
                Date = DateTime.Now,
                Message = message,
                Severity = SeverityType.Info
            });
        }

        [Subscribe]
        public void ProcessAction(DealUpdatedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Affaire id:'{0}' mise à jour", eventObject.DealId));
        }

        [Subscribe]
        public void ProcessAction(DealCreatedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Affaire id:'{0}' créée", eventObject.DealId));
        }

        [Subscribe]
        public void ProcessAction(DealDeletedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Affaire id:'{0}' supprimée", eventObject.DealId));
        }

        [Subscribe]
        public void ProcessAction(CatalogCreatedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Catalogue id:'{0}' créé", eventObject.CatalogId));
        }

        [Subscribe]
        public void ProcessAction(CatalogUpdatedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Catalogue id:'{0}' mis à jour", eventObject.CatalogId));
        }

        [Subscribe]
        public void ProcessAction(CatalogDeletedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Catalogue id:'{0}' supprimé", eventObject.CatalogId));
        }

        [Subscribe]
        public void ProcessAction(SupplyCreatedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Fourniture id:'{0}' ajoutée", eventObject.SupplyId));
        }

        [Subscribe]
        public void ProcessAction(SupplyUpdatedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Fourniture id:'{0}' mise à jour", eventObject.SupplyId));
        }

        [Subscribe]
        public void ProcessAction(SupplyDeletedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Fourniture id:'{0}' supprimé", eventObject.SupplyId));
        }

        [Subscribe]
        public void ProcessAction(HardwareCreatedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Matériel id:'{0}' ajouté", eventObject.HardwareId));
        }

        [Subscribe]
        public void ProcessAction(HardwareUpdatedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Matériel id:'{0}' mis à jour", eventObject.HardwareId));
        }

        [Subscribe]
        public void ProcessAction(HardwareDeletedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Matériel id:'{0}' supprimé", eventObject.HardwareId));
        }

        [Subscribe]
        public void ProcessAction(HardwareSupplyCreatedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Composant id:{0} du matériel id:'{1}' ajouté", eventObject.ComponentId, eventObject.HardwareId));
        }

        [Subscribe]
        public void ProcessAction(HardwareSupplyUpdatedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Composant id:{0} du matériel id:'{1}' mis à jour", eventObject.ComponentId, eventObject.HardwareId));
        }

        [Subscribe]
        public void ProcessAction(HardwareSupplyDeletedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Composant id:{0} du matériel id:'{1}' supprimé", eventObject.ComponentId, eventObject.HardwareId));
        }

        [Subscribe]
        public void ProcessAction(ProjectCreatedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Project id:'{0}' créé", eventObject.ProjectId));
        }

        [Subscribe]
        public void ProcessAction(ProjectUpdatedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Project id:'{0}' mis à jour", eventObject.ProjectId));
        }

        [Subscribe]
        public void ProcessAction(HardwareMustBeUniqueErrorEvent eventObject)
        {
            this.AppendErrorLog(string.Format("Le nom du matériel doit être unique"));
        }

        [Subscribe]
        public void ProcessAction(SupplyMustBeUniqueErrorEvent eventObject)
        {
            this.AppendErrorLog(string.Format("Le nom de la fourniture doit être unique"));
        }

        [Subscribe]
        public void ProcessAction(Object eventObject)
        {
            this.AppendInfoLog(eventObject.ToString());
        }
    }
}
