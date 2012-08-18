using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Catalogs.Module.Events;
using Chiffrage.Catalogs.Module.ViewModel;
using Chiffrage.Catalogs.Module.Views;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Views;
using Chiffrage.Catalogs.Module.Views.Impl.WizardPages;
using Chiffrage.Catalogs.Domain.Commands;

namespace Chiffrage.Catalogs.Module.Views.Impl
{
    public class EditHardwareWizardView : WizardView, IEditHardwareView
    {
        private GenericWizardSetting<EditHardwarePage> editHardwarePage;

        private CatalogHardwareViewModel hardware;

        public EditHardwareWizardView(IEventBroker eventBroker)
            : base(eventBroker)
        {
        }

        protected override IWizardSettingIterator BuildWizardPages()
        {

            this.editHardwarePage = new GenericWizardSetting<EditHardwarePage>("Edition d'un matériel",
                                                                         "Vous pouvez ici éditer un matériel", true);
            this.editHardwarePage.TypedPage.HardwareName = this.hardware.Name;
            this.editHardwarePage.TypedPage.ReferenceDays = this.hardware.ReferenceDays;
            this.editHardwarePage.TypedPage.StudyDays = this.hardware.StudyDays;
            this.editHardwarePage.TypedPage.CatalogExecutiveWorkDays = this.hardware.CatalogExecutiveWorkDays;
            this.editHardwarePage.TypedPage.CatalogTestDays = this.hardware.CatalogTestsDays;
            this.editHardwarePage.TypedPage.CatalogWorkDays = this.hardware.CatalogWorkDays;

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
                    this.editHardwarePage.TypedPage.StudyDays,
                    this.editHardwarePage.TypedPage.ReferenceDays,
                    this.editHardwarePage.TypedPage.CatalogWorkDays,
                    this.editHardwarePage.TypedPage.CatalogExecutiveWorkDays,
                    this.editHardwarePage.TypedPage.CatalogTestDays);
                this.EventBroker.Publish(command);
            }
        }

        public CatalogHardwareViewModel Hardware
        {
            set { this.hardware = value; }
        }

        public override string Name
        {
            get { return "Edition de matériel"; }
        }
    }
}
