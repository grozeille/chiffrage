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
    public class EditProjectHardwareExecutiveWorkWizardView : WizardView, IEditProjectHardwareEecutiveWorkView
    {
        private GenericWizardSetting<EditProjectHardwareExecutiveWorkPage> editHardwarePage;

        private ProjectHardwareExecutiveWorkViewModel hardware;

        public EditProjectHardwareExecutiveWorkWizardView(IEventBroker eventBroker)
            : base(eventBroker)
        {
        }

        protected override IWizardSettingIterator BuildWizardPages()
        {

            this.editHardwarePage = new GenericWizardSetting<EditProjectHardwareExecutiveWorkPage>("Edition d'un matériel",
                                                                         "Vous pouvez ici éditer un matériel", true);


            this.editHardwarePage.TypedPage.HardwareName = this.hardware.Name;
            this.editHardwarePage.TypedPage.CatalogExecutiveWorkDays = this.hardware.CatalogExecutiveWorkDays;
            this.editHardwarePage.TypedPage.ExecutiveWorkDays = this.hardware.ExecutiveWorkDays;
            this.editHardwarePage.TypedPage.ExecutiveWorkShortNights = this.hardware.ExecutiveWorkShortNights;
            this.editHardwarePage.TypedPage.ExecutiveWorkLongNights = this.hardware.ExecutiveWorkLongNights;

            return new WizardSettingListIterator(this.editHardwarePage);
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if(result == DialogResult.OK)
            {
                var command = new UpdateProjectHardwareExecutiveWorkCommand(
                    hardware.ProjectId,
                    hardware.Id,
                    this.editHardwarePage.TypedPage.ExecutiveWorkDays,
                    this.editHardwarePage.TypedPage.ExecutiveWorkShortNights,
                    this.editHardwarePage.TypedPage.ExecutiveWorkLongNights);
                this.EventBroker.Publish(command);
            }
        }

        public ProjectHardwareExecutiveWorkViewModel Hardware
        {
            set { this.hardware = value; }
        }

        public override string Name
        {
            get { return "Edition de matériel"; }
        }
    }
}
