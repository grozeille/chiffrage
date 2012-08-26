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
using Chiffrage.Catalogs.Remoting.Contracts.Services;
using Chiffrage.Catalogs.Remoting.Contracts;
using Common.Logging;

namespace Chiffrage.Excel
{
    [ComVisible(true)]
    public class ChiffrageRibbon : ExcelDna.Integration.CustomUI.ExcelRibbon
    {
        private readonly ILog logger = LogManager.GetLogger<ChiffrageRibbon>();

        public void ShowImportCatalogWizard()
        {
            ChiffrageExcelAddin.EventBroker.Publish(new ShowImportCatalogWizard());
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
