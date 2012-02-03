using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.App.Views;
using Chiffrage.Mvc.Views;
using Chiffrage.WizardPages;
using Chiffrage.Mvc.Events;
using Chiffrage.App.Events;
using Chiffrage.Projects.Domain.Commands;

namespace Chiffrage
{
    public class NewWizardWizardView : WizardView
    {
        public IList<WizardView> Wizards { get; set; }

        public NewWizardWizardView(IEventBroker eventBroker)
            : base(eventBroker)
        {
            
        }

        protected override IWizardSettingIterator BuildWizardPages()
        {
            foreach (var item in this.Wizards)
            {
                item.PrepareView();
            }
            return new WizardViewListIterator(this.Wizards);
        }

        protected override void OnWizardClosed(DialogResult result)
        {
        }

        public override string Name
        {
            get { return "Assistant"; }
        }
    }
}
