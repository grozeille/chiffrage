using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Catalogs.Module.Views;
using Chiffrage.Mvc.Views;
using Chiffrage.Catalogs.Module.Views.Impl.WizardPages;
using Chiffrage.Mvc.Events;
using Chiffrage.Catalogs.Module.Actions;
using Chiffrage.Catalogs.Module.ViewModel;
using Chiffrage.Catalogs.Domain.Commands;
using Chiffrage.Common.Module.Views.WizardPages;

namespace Chiffrage.Catalogs.Module.Views.Impl
{
    public class NewHardwareSupplyWizardView : WizardView, INewHardwareSupplyView
    {
        private int parentHardwareId;

        private int catalogId;

        private IList<CatalogSupplyViewModel> supplies;

        private GenericWizardSetting<NewHardwareSupplyPage> newHardwareSupplyPage;

        private GenericWizardSetting<CommentPage> commentPage;

        public NewHardwareSupplyWizardView(IEventBroker eventBroker)
            :base(eventBroker)
        {
            
        }

        protected override IWizardSettingIterator BuildWizardPages()
        {
            this.newHardwareSupplyPage = new GenericWizardSetting<NewHardwareSupplyPage>("Nouveau composant de matériel", "Ajout d'un composant au matériel", true);
            this.newHardwareSupplyPage.TypedPage.Supplies = this.supplies;
            this.commentPage = new GenericWizardSetting<CommentPage>("Nouveau composant de matériel", "Ajout d'un composant au matériel", true);

            return new WizardSettingListIterator(this.newHardwareSupplyPage, this.commentPage);
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if (result == DialogResult.OK)
            {
                this.EventBroker.Publish(new CreateNewHardwareSupplyCommand(
                    this.catalogId, 
                    this.parentHardwareId, 
                    this.newHardwareSupplyPage.TypedPage.SelectedSupply, 
                    this.newHardwareSupplyPage.TypedPage.Quantity,
                    this.commentPage.TypedPage.Comment), "topic://commands");
            }
        }

        public int CatalogId
        {
            set { this.catalogId = value; }
        }

        public IList<CatalogSupplyViewModel> Supplies
        {
            set { this.supplies = value; }
        }


        public int ParentHardwareId
        {
            set { this.parentHardwareId = value; }
        }

        public override string Name
        {
            get { return "Ajout de composant de matériel"; }
        }
    }
}
