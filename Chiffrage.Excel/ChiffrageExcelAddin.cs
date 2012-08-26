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

namespace Chiffrage.Excel
{
    public class ChiffrageExcelAddin : IExcelAddIn
    {
        private static Microsoft.Office.Interop.Excel.Application application;

        private static EventBroker eventBroker;

        public static Microsoft.Office.Interop.Excel.Application Application
        {
            get
            {
                return ChiffrageExcelAddin.application;
            }
        }

        public static EventBroker EventBroker
        {
            get
            {
                return ChiffrageExcelAddin.eventBroker;
            }
        }

        [ExcelCommandAttribute(MenuName="Chiffrage", MenuText="Importer un catalogue")]
        public static void ShowImportWizardCommand()
        {
            var caller = (ExcelReference)XlCall.Excel(XlCall.xlfCaller);
            
            Debugger.Launch();
            System.Windows.Forms.MessageBox.Show("Hello");
            var data = new object[2,2];
            data[0,0] = "Hello";
            data[0,1] = "Mathias";
            data[1,0] = "How";
            data[1,1] = "Are you?";
            var reference = new ExcelReference(1, 1, 2, 2);
            reference.SetValue(data);
            application.Range["C5"].Value = "Moi je suis C5 ;)";
        }

        public void AutoClose()
        {
            Marshal.ReleaseComObject(application);
            Marshal.FinalReleaseComObject(application);
            application = null;
        }

        public void AutoOpen()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            ChiffrageExcelAddin.application = (Microsoft.Office.Interop.Excel.Application)ExcelDnaUtil.Application;
            ChiffrageExcelAddin.eventBroker = new EventBroker();

            NameValueCollection properties = new NameValueCollection();
            properties["configType"] = "EXTERNAL";

            // set Adapter
            Common.Logging.LogManager.Adapter = new Log4NetLoggerFactoryAdapter(properties);

            XmlConfigurator.Configure(this.GetType().Assembly.GetManifestResourceStream("Chiffrage.Excel.Config.log4net.config"));
        }
    }
}
