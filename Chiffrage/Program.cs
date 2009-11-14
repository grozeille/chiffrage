using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Grozeille.Chiffrage.Core;
using System.Threading;

namespace Chiffrage
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Catalog catalog = null;

            var form = new LoadingForm();
            form.OnLoadingApplication = new EventHandler<LoadingEventArgs>(delegate(object sender, LoadingEventArgs args)
                                            {
                                                args.ReportProgress(10);
                                                Thread.Sleep(500);
                                                args.ReportProgress(40);
                                                Thread.Sleep(500);
                                                args.ReportProgress(60);
                                                Thread.Sleep(500);
                                                catalog = new Catalog();                                                
                                                var supplierCatalog = new SupplierCatalog();
                                                supplierCatalog.SupplierName = "Mathias";
                                                supplierCatalog.Supplies.Add(new Supply
                                                {
                                                    Category = "Cable",
                                                    Name = "20mm",
                                                    Reference = "C20MM",
                                                    ModuleSize = 0,
                                                    Price = 10.1,
                                                    ReferenceDays = 0,
                                                    StudyDays = 0,
                                                    TestsDays = 2,
                                                    WorkDays = 2
                                                });
                                                supplierCatalog.Supplies.Add(new Supply
                                                {
                                                    Category = "Test",
                                                    Name = "Test",
                                                    Reference = "C3MM",
                                                    ModuleSize = 0,
                                                    Price = 10.1,
                                                    ReferenceDays = 0,
                                                    StudyDays = 0,
                                                    TestsDays = 2,
                                                    WorkDays = 2
                                                });
                                                catalog.SupplierCatalogs.Add(supplierCatalog);
                                                args.ReportProgress(100);
                                            });
            Application.Run(form);
            var formMain = new FormMain();
            formMain.Catalog = catalog;
            Application.Run(formMain);
        }
    }
}
