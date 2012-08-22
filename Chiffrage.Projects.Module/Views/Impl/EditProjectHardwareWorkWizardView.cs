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
    public class EditProjectHardwareWorkWizardView : WizardView, IEditProjectHardwareWorkView
    {
        private GenericWizardSetting<EditProjectHardwareWorkPage> editHardwarePage;

        private ProjectHardwareWorkViewModel hardware;

        public EditProjectHardwareWorkWizardView(IEventBroker eventBroker)
            : base(eventBroker)
        {
        }

        protected override IWizardSettingIterator BuildWizardPages()
        {

            this.editHardwarePage = new GenericWizardSetting<EditProjectHardwareWorkPage>("Edition d'un matériel",
                                                                         "Vous pouvez ici éditer un matériel", true);


            this.editHardwarePage.TypedPage.HardwareName = this.hardware.Name;
            this.editHardwarePage.TypedPage.CatalogWorkDays = this.hardware.CatalogWorkDays;
            this.editHardwarePage.TypedPage.WorkDays = this.hardware.WorkDays;
            this.editHardwarePage.TypedPage.WorkShortNights = this.hardware.WorkShortNights;
            this.editHardwarePage.TypedPage.WorkLongNights = this.hardware.WorkLongNights;

            return new WizardSettingListIterator(this.editHardwarePage);
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if(result == DialogResult.OK)
            {
                var command = new UpdateProjectHardwareWorkCommand(
                    hardware.ProjectId,
                    hardware.Id,
                    this.editHardwarePage.TypedPage.WorkDays,
                    this.editHardwarePage.TypedPage.WorkShortNights,
                    this.editHardwarePage.TypedPage.WorkLongNights);
                this.EventBroker.Publish(command);
            }
        }

        public ProjectHardwareWorkViewModel Hardware
        {
            set { this.hardware = value; }
        }

        public override string Name
        {
            get { return "Edition de matériel"; }
        }
    }
}
