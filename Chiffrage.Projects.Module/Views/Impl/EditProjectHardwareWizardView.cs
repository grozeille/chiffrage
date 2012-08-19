﻿using System;
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
    public class EditProjectHardwareWizardView : WizardView, IEditProjectHardwareView
    {
        private GenericWizardSetting<EditProjectHardwarePage> editHardwarePage;

        private ProjectHardwareViewModel hardware;

        public EditProjectHardwareWizardView(IEventBroker eventBroker)
            : base(eventBroker)
        {
        }

        protected override IWizardSettingIterator BuildWizardPages()
        {

            this.editHardwarePage = new GenericWizardSetting<EditProjectHardwarePage>("Edition d'un matériel",
                                                                         "Vous pouvez ici éditer un matériel", true);


            this.editHardwarePage.TypedPage.Quantity = this.hardware.Quantity;

            this.editHardwarePage.TypedPage.HardwareName = this.hardware.Name;
            this.editHardwarePage.TypedPage.ReferenceDays = this.hardware.ReferenceDays;
            this.editHardwarePage.TypedPage.StudyDays = this.hardware.StudyDays;
            this.editHardwarePage.TypedPage.ExecutiveWorkDays = this.hardware.ExecutiveWorkDays;
            this.editHardwarePage.TypedPage.TestDays = this.hardware.TestsDays;
            this.editHardwarePage.TypedPage.WorkDays = this.hardware.WorkDays;

            this.editHardwarePage.TypedPage.CatalogReferenceDays = this.hardware.CatalogReferenceDays;
            this.editHardwarePage.TypedPage.CatalogStudyDays = this.hardware.CatalogStudyDays;
            this.editHardwarePage.TypedPage.CatalogExecutiveWorkDays = this.hardware.CatalogExecutiveWorkDays;
            this.editHardwarePage.TypedPage.CatalogTestDays = this.hardware.CatalogTestsDays;
            this.editHardwarePage.TypedPage.CatalogWorkDays = this.hardware.CatalogWorkDays;

            return new WizardSettingListIterator(this.editHardwarePage);
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if(result == DialogResult.OK)
            {
                var command = new UpdateProjectHardwareCommand(
                    hardware.ProjectId,
                    hardware.Id,
                    hardware.Quantity,
                    this.editHardwarePage.TypedPage.HardwareName,
                    this.editHardwarePage.TypedPage.StudyDays,
                    this.editHardwarePage.TypedPage.ReferenceDays,
                    this.editHardwarePage.TypedPage.WorkDays,
                    this.editHardwarePage.TypedPage.ExecutiveWorkDays,
                    this.editHardwarePage.TypedPage.TestDays);
                this.EventBroker.Publish(command);
            }
        }

        public ProjectHardwareViewModel Hardware
        {
            set { this.hardware = value; }
        }

        public override string Name
        {
            get { return "Edition de matériel"; }
        }
    }
}
