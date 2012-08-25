using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExcelDna.Integration.CustomUI;
using System.Diagnostics;
using ExcelDna.Integration;
using System.Runtime.InteropServices;

namespace Chiffrage.Excel
{
    [ComVisible(true)]
    public class ChiffrageRibbon : ExcelDna.Integration.CustomUI.ExcelRibbon
    {
        public void ShowImportCatalogWizard()
        {
            //MessageBox.Show("Hello");
            var reference = new ExcelReference(1,1);
            reference.SetValue("Hello");
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
