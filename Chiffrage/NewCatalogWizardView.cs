using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.App.Views;
using Chiffrage.WizardPages;
using Chiffrage.Mvc.Events;
using Chiffrage.App.Events;

namespace Chiffrage
{
    public class NewCatalogWizardView : INewCatalogView
    {
        private readonly IEventBroker eventBroker;

        private Control parent;

        private readonly WizardForm form;

        public NewCatalogWizardView(IEventBroker eventBroker)
        {
            this.eventBroker = eventBroker;
            this.form = new WizardForm();
        }

        public void SetParent(Control parent)
        {
            this.parent = parent;
        }

        public void ShowView()
        {
            var newCatalogPage = new NewCatalogPage();

            this.form.WizardSettings = new[]
            {
                new WizardSetting(newCatalogPage, "Nouveau catalogue", "Création d'un nouveau catalogue fournisseur", true)
            }; 

            this.parent.BeginInvoke(new Action(() =>
            {
                var result = this.form.ShowDialog(this.parent);
                if (result == DialogResult.OK)
                {
                    this.eventBroker.Publish(new CreateNewCatalogEvent(newCatalogPage.SupplierName));
                }
            }));            
        }

        public void HideView()
        {
            this.form.Close();
        }
    }
}
