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
    public class EditProjectHardwareStudyReferenceTestsWizardView : WizardView, IEditProjectHardwareStudyReferenceTestsView
    {
        private GenericWizardSetting<EditProjectHardwareStudyReferenceTestPage> editHardwarePage;

        private ProjectHardwareStudyReferenceTestViewModel hardware;

        public EditProjectHardwareStudyReferenceTestsWizardView(IEventBroker eventBroker)
            : base(eventBroker)
        {
        }

        protected override IWizardSettingIterator BuildWizardPages()
        {

            this.editHardwarePage = new GenericWizardSetting<EditProjectHardwareStudyReferenceTestPage>("Edition d'un matériel",
                                                                         "Vous pouvez ici éditer un matériel", true);


            this.editHardwarePage.TypedPage.HardwareName = this.hardware.Name;
            this.editHardwarePage.TypedPage.CatalogStudyDays = this.hardware.CatalogStudyDays;
            this.editHardwarePage.TypedPage.CatalogReferenceDays = this.hardware.CatalogReferenceDays;
            this.editHardwarePage.TypedPage.CatalogTestsDays = this.hardware.CatalogTestsDays;
            this.editHardwarePage.TypedPage.StudyDays = this.hardware.StudyDays;
            this.editHardwarePage.TypedPage.ReferenceDays = this.hardware.ReferenceDays;
            this.editHardwarePage.TypedPage.TestsDays = this.hardware.TestsDays;
            this.editHardwarePage.TypedPage.TestsNights = this.hardware.TestsNights;

            return new WizardSettingListIterator(this.editHardwarePage);
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if(result == DialogResult.OK)
            {
                var command = new UpdateProjectHardwareStudyReferenceTestsCommand(
                    hardware.ProjectId,
                    hardware.Id,
                    this.editHardwarePage.TypedPage.StudyDays,
                    this.editHardwarePage.TypedPage.ReferenceDays,
                    this.editHardwarePage.TypedPage.TestsDays,
                    this.editHardwarePage.TypedPage.TestsNights);
                this.EventBroker.Publish(command);
            }
        }

        public ProjectHardwareStudyReferenceTestViewModel Hardware
        {
            set { this.hardware = value; }
        }

        public override string Name
        {
            get { return "Edition de matériel"; }
        }
    }
}
