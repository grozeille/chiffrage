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
    public class EditProjectHardwareTechnicianWorkWizardView : WizardView, IEditProjectHardwareTechnicianWorkView
    {
        private GenericWizardSetting<EditProjectHardwareTechnicianWorkPage> editHardwarePage;

        private ProjectHardwareTechnicianWorkViewModel hardware;

        public EditProjectHardwareTechnicianWorkWizardView(IEventBroker eventBroker)
            : base(eventBroker)
        {
        }

        protected override IWizardSettingIterator BuildWizardPages()
        {

            this.editHardwarePage = new GenericWizardSetting<EditProjectHardwareTechnicianWorkPage>("Edition d'un matériel",
                                                                         "Vous pouvez ici éditer un matériel", true);


            this.editHardwarePage.TypedPage.HardwareName = this.hardware.Name;
            this.editHardwarePage.TypedPage.CatalogWorkDays = this.hardware.CatalogTechnicianWorkDays;
            this.editHardwarePage.TypedPage.WorkDays = this.hardware.TechnicianWorkDays;
            this.editHardwarePage.TypedPage.WorkShortNights = this.hardware.TechnicianWorkShortNights;
            this.editHardwarePage.TypedPage.WorkLongNights = this.hardware.TechnicianWorkLongNights;

            return new WizardSettingListIterator(this.editHardwarePage);
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if(result == DialogResult.OK)
            {
                var command = new UpdateProjectHardwareTechnicianWorkCommand(
                    hardware.ProjectId,
                    hardware.Id,
                    this.editHardwarePage.TypedPage.WorkDays,
                    this.editHardwarePage.TypedPage.WorkShortNights,
                    this.editHardwarePage.TypedPage.WorkLongNights);
                this.EventBroker.Publish(command);
            }
        }

        public ProjectHardwareTechnicianWorkViewModel Hardware
        {
            set { this.hardware = value; }
        }

        public override string Name
        {
            get { return "Edition de matériel"; }
        }
    }
}
