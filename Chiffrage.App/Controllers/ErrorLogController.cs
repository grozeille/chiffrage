﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.App.ViewModel;
using Chiffrage.App.Views;
using Chiffrage.Mvc.Events;
using Chiffrage.App.Events;

namespace Chiffrage.App.Controllers
{
    public class ErrorLogController : 
        IGenericEventHandler<ErrorEvent>,
        IGenericEventHandler<CatalogUpdatedEvent>,
        IGenericEventHandler<DealUpdatedEvent>
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
    }
}