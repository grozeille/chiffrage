using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.App.Events;
using Chiffrage.App.Views;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Controllers;

namespace Chiffrage.App.Controllers
{
    public class ApplicationController: IController
    {
        private readonly IApplicationView applicationView;

        public ApplicationController(IApplicationView applicationView)
        {
            this.applicationView = applicationView;
        }

        [Subscribe]
        public void ProcessAction(ApplicationLoadedEvent eventObject)
        {
            if (eventObject.Position == eventObject.Max)
            {
                this.applicationView.ShowView();
            }
        }
    }
}
