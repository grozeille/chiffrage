using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Mvc.Views;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Wizards
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
