﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.App.Views;
using Chiffrage.Mvc.Views;
using Chiffrage.WizardPages;
using System.Windows.Forms;
using Chiffrage.Projects.Domain.Commands;
using Chiffrage.Mvc.Events;

namespace Chiffrage.Wizards
{
    public class NewProjectFrameWizardView : WizardView, INewProjectFrameView
    {
        private int projectId;

        public NewProjectFrameWizardView(IEventBroker eventBroker) : base(eventBroker)
        {

        }

        private GenericWizardSetting<ProjectFramePage> newProjectFramePage;

        protected override IWizardSettingIterator BuildWizardPages()
        {
            this.newProjectFramePage = new GenericWizardSetting<ProjectFramePage>("Nouveau chassis", "Ajout d'un chassis", true);

            return new WizardSettingListIterator(this.newProjectFramePage);
        }

        public override string Name
        {
            get { return "Ajout d'un Chassis"; }
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if (result == DialogResult.OK)
            {
                var command = new CreateNewProjectFrameCommand(this.projectId, newProjectFramePage.TypedPage.FrameSize, newProjectFramePage.TypedPage.FrameCount);

                this.EventBroker.Publish(command);
            }
        }

        public int ProjectId
        {
            set { this.projectId = value; }
        }
    }
}