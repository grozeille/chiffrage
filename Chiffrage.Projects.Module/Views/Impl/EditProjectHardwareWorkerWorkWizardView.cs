using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Projects.Module.Actions;
using Chiffrage.Projects.Module.ViewModel;
using Chiffrage.Projects.Module.Views;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Views;
using Chiffrage.Projects.Module.Views.Impl.WizardPages;
using Chiffrage.Catalogs.Domain.Commands;
using Chiffrage.Projects.Domain.Commands;

namespace Chiffrage.Projects.Module.Views.Impl
{
    public class EditProjectHardwareWorkerWorkWizardView : WizardView, IEditProjectHardwareWorkerWorkView
    {
        private GenericWizardSetting<EditProjectHardwareWorkerWorkPage> editHardwarePage;

        private ProjectHardwareWorkerWorkViewModel hardware;

        public EditProjectHardwareWorkerWorkWizardView(IEventBroker eventBroker)
            : base(eventBroker)
        {
        }

        protected override IWizardSettingIterator BuildWizardPages()
        {

            this.editHardwarePage = new GenericWizardSetting<EditProjectHardwareWorkerWorkPage>("Edition d'un matériel",
                                                                         "Vous pouvez ici éditer un matériel", true);


            this.editHardwarePage.TypedPage.HardwareName = this.hardware.Name;
            this.editHardwarePage.TypedPage.CatalogWorkerWorkDays = this.hardware.CatalogWorkerWorkDays;
            this.editHardwarePage.TypedPage.WorkerWorkDays = this.hardware.WorkerWorkDays;
            this.editHardwarePage.TypedPage.WorkerWorkShortNights = this.hardware.WorkerWorkShortNights;
            this.editHardwarePage.TypedPage.WorkerWorkLongNights = this.hardware.WorkerWorkLongNights;

            return new WizardSettingListIterator(this.editHardwarePage);
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if(result == DialogResult.OK)
            {
                var command = new UpdateProjectHardwareWorkerWorkCommand(
                    hardware.ProjectId,
                    hardware.Id,
                    this.editHardwarePage.TypedPage.WorkerWorkDays,
                    this.editHardwarePage.TypedPage.WorkerWorkShortNights,
                    this.editHardwarePage.TypedPage.WorkerWorkLongNights);
                this.EventBroker.Publish(command);
            }
        }

        public ProjectHardwareWorkerWorkViewModel Hardware
        {
            set { this.hardware = value; }
        }

        public override string Name
        {
            get { return "Edition de matériel"; }
        }
    }
}
