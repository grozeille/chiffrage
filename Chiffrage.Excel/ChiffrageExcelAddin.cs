using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcelDna.Integration;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using Chiffrage.Mvc.Events;
using Common.Logging;
using log4net.Config;
using System.Collections.Specialized;
using Common.Logging.Log4Net;
using Chiffrage.Excel.Actions;
using Chiffrage.Catalogs.Remoting.Contracts.Services;
using Chiffrage.Excel.Views;
using Chiffrage.Catalogs.Remoting.Contracts;
using System.Threading;
using System.Globalization;

namespace Chiffrage.Excel
{
    public class ChiffrageExcelAddin : IExcelAddIn
    {
        private readonly ILog logger = LogManager.GetLogger<ChiffrageExcelAddin>();

        private ICatalogRemoteService catalogRemoteService;

        private ImportCatalogWizardView view;

        private readonly object lockObject = new object();

        //private static Microsoft.Office.Interop.Excel.Application application;
        //public static Microsoft.Office.Interop.Excel.Application Application
        //{
        //    get
        //    {
        //        return ChiffrageExcelAddin.application;
        //    }
        //}

        private static EventBroker eventBroker;

        public static EventBroker EventBroker
        {
            get
            {
                return ChiffrageExcelAddin.eventBroker;
            }
        }

        private ICatalogRemoteService GetCatalogRemoteService()
        {
            lock (lockObject)
            {
                if (this.catalogRemoteService == null)
                {
                    this.catalogRemoteService = (ICatalogRemoteService)Activator.GetObject(
                        typeof(ICatalogRemoteService),
                        string.Format("tcp://localhost:{0}/{1}", Consts.Port, Consts.ServiceName));

                    this.catalogRemoteService.Ping();
                }

                return this.catalogRemoteService;
            }
        }

        public static void ShowImportWizardCommand()
        {
            var wait = ChiffrageExcelAddin.EventBroker.PublishAndWait(new ShowImportCatalogWizard());
            wait.AsyncWaitHandle.WaitOne();
        }

        public void AutoClose()
        {
            logger.InfoFormat("Closed");
        }

        public void AutoOpen()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            System.Windows.Forms.Application.EnableVisualStyles();
            ChiffrageExcelAddin.eventBroker = new EventBroker();
            ChiffrageExcelAddin.eventBroker.Subscribe(this);

            this.view = new ImportCatalogWizardView(ChiffrageExcelAddin.EventBroker);
    
            AppDomain.CurrentDomain.UnhandledException += (sender, ex) => { logger.Error("UnhandledException", (Exception)ex.ExceptionObject); };

            logger.InfoFormat("Loaded");
        }

        [Subscribe]
        public void OnShowImportCatalogWizard(ShowImportCatalogWizard eventObject)
        {
            try
            {
                var catalogs = GetCatalogRemoteService().GetCatalogs();
                view.CatalogItem = catalogs;
                view.ShowView();
            }
            catch (Exception ex)
            {
                logger.Error("Unable to connect to Chiffrage", ex);

            }
        }

        [Subscribe(SubscriptionMode=SubscriptionMode.UIThread)]
        public void OnRequestImportCatalog(RequestImportCatalogAction action)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

                var result = this.GetCatalogRemoteService().GetCatalogData(action.CatalogItem.Id);


                int rows = result.GetLength(0);
                int cols = result.GetLength(1);

                var application = (Microsoft.Office.Interop.Excel.Application)ExcelDnaUtil.Application;

                var cell = application.ActiveCell;

                var range = cell.Resize[rows, cols];

                range.Value = result;


                Marshal.ReleaseComObject(range);
                range = null;
                Marshal.ReleaseComObject(cell);
                cell = null;
                Marshal.ReleaseComObject(application);
                application = null;
            }
            catch (Exception ex)
            {
                logger.Error("Unable to import catalog", ex);

            }
        }
    }
}
