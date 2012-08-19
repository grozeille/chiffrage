using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Chiffrage.Mvc.Sample.Controllers;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Sample.Services;

namespace Chiffrage.Mvc.Sample
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

            var eventBroker = new EventBroker();
            
            var form = new FormMain();
            var controller1 = new Controller();
            controller1.EventBroker = eventBroker;
            controller1.ChatView = form.ChatView1;

            var controller2 = new Controller();
            controller2.EventBroker = eventBroker;
            controller2.ChatView = form.ChatView2;

            var service = new Service();
            service.EventBroker = eventBroker;



            eventBroker.UISynchronizationContext = WindowsFormsSynchronizationContext.Current;
            eventBroker.Subscribers = new IEventHandler[] { controller1, controller2, service };
            eventBroker.Start();

            Application.Run(form);

            eventBroker.Stop();
        }
    }
}
