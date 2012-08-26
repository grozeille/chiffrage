using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExcelDna.Integration.CustomUI;
using System.Diagnostics;
using ExcelDna.Integration;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using Chiffrage.Catalogs.Remoting;
using Chiffrage.Excel.Views;
using Chiffrage.Excel.Actions;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Excel
{
    [ComVisible(true)]
    public class ChiffrageRibbon : ExcelDna.Integration.CustomUI.ExcelRibbon
    {
        private ICatalogRemoteService catalogRemoteService;

        private ImportCatalogWizardView view;

        public override void OnStartupComplete(ref Array custom)
        {
            base.OnStartupComplete(ref custom);
        }

        public ICatalogRemoteService GetCatalogRemoteService()
        {
            if (this.catalogRemoteService == null)
            {
                ChiffrageExcelAddin.EventBroker.Subscribe(this);

                this.view = new ImportCatalogWizardView(ChiffrageExcelAddin.EventBroker);

                this.catalogRemoteService = (ICatalogRemoteService)Activator.GetObject(
                    typeof(ICatalogRemoteService),
                    string.Format("tcp://localhost:{0}/{1}", Consts.Port, Consts.ServiceName));

                this.catalogRemoteService.Ping();
            }

            return this.catalogRemoteService;
        }

        [Subscribe]
        public void OnRequestImportCatalog(RequestImportCatalogAction action)
        {
            var result = this.GetCatalogRemoteService().GetCatalogData(action.CatalogItem.Id);

            int rows = result.GetLength(0);
            int cols = result.GetLength(1);

            var application =  ChiffrageExcelAddin.Application;
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

        public void ShowImportCatalogWizard()
        {
            try
            {
                var catalogs = GetCatalogRemoteService().GetCatalogs();
                view.CatalogItem = catalogs;
                view.ShowView();
            }
            catch (Exception ex)
            {
                ExcelDna.Logging.LogDisplay.WriteLine(ex.ToString());
            }
        }

        public void OnRibbonImportCatalogWizardClick(IRibbonControl ribbon)
        {
            ShowImportCatalogWizard();
        }

        public void OnButtonPressed(IRibbonControl ribbon)
        {
            ShowImportCatalogWizard();
        }
    }
}
