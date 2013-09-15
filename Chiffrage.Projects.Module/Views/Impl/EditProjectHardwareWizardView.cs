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
using Chiffrage.Projects.Domain;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.Projects.Module.Views.Impl
{
    public class EditProjectHardwareWizardView : WizardView, IEditProjectHardwareView
    {
        private GenericWizardSetting<EditProjectHardwarePage> editHardwarePage;

        private ProjectHardwareViewModel hardware;

        private IList<ProjectTask> projectTasks;

        private IList<ProjectHardwareTask> hardwareTasks;

        public EditProjectHardwareWizardView(IEventBroker eventBroker)
            : base(eventBroker)
        {
        }

        protected override IWizardSettingIterator BuildWizardPages()
        {

            this.editHardwarePage = new GenericWizardSetting<EditProjectHardwarePage>("Edition d'un matériel",
                                                                         "Vous pouvez ici éditer un matériel", true);

            this.editHardwarePage.TypedPage.HardwareName = this.hardware.Name;
            this.editHardwarePage.TypedPage.Milestone = this.hardware.Milestone;
            this.editHardwarePage.TypedPage.ProjectTasks = this.projectTasks;
            this.editHardwarePage.TypedPage.HardwareTasks = this.hardwareTasks;

            return new WizardSettingListIterator(this.editHardwarePage);
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if(result == DialogResult.OK)
            {
                var command = new UpdateProjectHardwareCommand(
                    hardware.ProjectId,
                    hardware.Id,
                    this.editHardwarePage.TypedPage.Milestone,
                    this.editHardwarePage.TypedPage.HardwareTasks);
                this.EventBroker.Publish(command, "topic://commands");
            }
        }

        public ProjectHardwareViewModel Hardware
        {
            set { this.hardware = value; }
        }

        public IList<ProjectTask> ProjectTasks
        {
            set
            {
                this.projectTasks = value;
            }
        }

        public IList<ProjectHardwareTask> HardwareTask
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
