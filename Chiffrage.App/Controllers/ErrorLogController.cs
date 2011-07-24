using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.App.ViewModel;
using Chiffrage.App.Views;
using Chiffrage.Mvc.Events;
using Chiffrage.App.Events;
using Chiffrage.Mvc.Controllers;

namespace Chiffrage.App.Controllers
{
    public class ErrorLogController :
        IController,
        IGenericEventHandler<ErrorEvent>,
        IGenericEventHandler<CatalogUpdatedEvent>,
        IGenericEventHandler<CatalogCreatedEvent>,
        IGenericEventHandler<DealUpdatedEvent>,
        IGenericEventHandler<DealCreatedEvent>,
        IGenericEventHandler<SupplyCreatedEvent>,
        IGenericEventHandler<SupplyUpdatedEvent>
    {
        private readonly IErrorLogView view;

        public ErrorLogController(IErrorLogView view)
        {
            this.view = view;
        }

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

        public void ProcessAction(CatalogUpdatedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Catalog '{0}' updated successfully", eventObject.NewCatalog.SupplierName));
        }

        public void ProcessAction(DealUpdatedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Deal '{0}' updated successfully", eventObject.NewDeal.Name));
        }

        public void ProcessAction(DealCreatedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Deal '{0}' created successfully", eventObject.NewDeal.Name));
        }

        public void ProcessAction(CatalogCreatedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Catalog '{0}' created successfully", eventObject.NewCatalog.SupplierName));
        }

        public void ProcessAction(SupplyCreatedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Supply '{0}' added successfully", eventObject.Supply.Name));
        }

        public void ProcessAction(SupplyUpdatedEvent eventObject)
        {
            this.AppendInfoLog(string.Format("Supply '{0}' updated successfully", eventObject.Supply.Name));
        }
    }
}
