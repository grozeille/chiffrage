using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Catalogs.Module.Actions;
using Chiffrage.Catalogs.Module.ViewModel;
using Chiffrage.Catalogs.Module.Views;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Views;
using Chiffrage.Catalogs.Module.Views.Impl.WizardPages;
using Chiffrage.Catalogs.Domain.Commands;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.Catalogs.Module.Views.Impl
{
    public class EditHardwareWizardView : WizardView, IEditHardwareView
    {
        private GenericWizardSetting<EditHardwarePage> editHardwarePage;

        private CatalogHardwareViewModel hardware;

        private IList<Task> catalogTasks;

        private IList<HardwareTask> hardwareTasks;

        public EditHardwareWizardView(IEventBroker eventBroker)
            : base(eventBroker)
        {
        }

        protected override IWizardSettingIterator BuildWizardPages()
        {

            this.editHardwarePage = new GenericWizardSetting<EditHardwarePage>("Edition d'un matériel",
                                                                         "Vous pouvez ici éditer un matériel", true);
            this.editHardwarePage.TypedPage.HardwareName = this.hardware.Name;
            this.editHardwarePage.TypedPage.CatalogTasks = this.catalogTasks;
            this.editHardwarePage.TypedPage.HardwareTasks = this.hardwareTasks;

            return new WizardSettingListIterator(this.editHardwarePage);
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if(result == DialogResult.OK)
            {
                var command = new UpdateHardwareCommand(
                    hardware.CatalogId,
                    hardware.Id,
                    this.editHardwarePage.TypedPage.HardwareName,
                    this.editHardwarePage.TypedPage.HardwareTasks);
                this.EventBroker.Publish(command, "topic://commands");
            }
        }

        public CatalogHardwareViewModel Hardware
        {
            set { this.hardware = value; }
        }

        public IList<Task> CatalogTasks
        {
            set
            {
                this.catalogTasks = value;
            }
        }

        public IList<HardwareTask> HardwareTask
        {
            set
            {
                this.hardwareTasks = value;
            }
        }

        public override string Name
        {
            get { return "Edition de matériel"; }
        }
    }
}
