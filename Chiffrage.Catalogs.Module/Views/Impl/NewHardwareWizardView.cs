﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Chiffrage.Catalogs.Module.Actions;
using Chiffrage.Catalogs.Module.Views;
using Chiffrage.Mvc.Events;
using Chiffrage.Mvc.Views;
using Chiffrage.Catalogs.Module.Views.Impl.WizardPages;
using Chiffrage.Catalogs.Domain.Commands;
using Chiffrage.Catalogs.Module.ViewModel;
using Chiffrage.Catalogs.Domain;

namespace Chiffrage.Catalogs.Module.Views.Impl
{
    public class NewHardwareWizardView : WizardView, INewHardwareView
    {
        private int catalogId;

        private IList<Task> tasks;

        private GenericWizardSetting<NewHardwarePage> newHardwarePage;

        public NewHardwareWizardView(IEventBroker eventBroker)
            : base(eventBroker)
        {
        }

        protected override IWizardSettingIterator BuildWizardPages()
        {
            this.newHardwarePage = new GenericWizardSetting<NewHardwarePage>("Création d'une matériel",
                                                                         "Vous pouvez ici créer un nouveau matériel", true);

            this.newHardwarePage.TypedPage.Tasks = tasks;

            return new WizardSettingListIterator(this.newHardwarePage);
        }

        protected override void OnWizardClosed(DialogResult result)
        {
            if(result == DialogResult.OK)
            {


                this.EventBroker.Publish(new CreateNewHardwareCommand(
                    this.catalogId,
                    newHardwarePage.TypedPage.HardwareName,
                    newHardwarePage.TypedPage.HardwareTasks), Topics.COMMANDS);
            }
        }

        public int CatalogId
        {
            set { this.catalogId = value; }
        }

        public IList<Task> Tasks
        {
            set { this.tasks = value; }
        }

        public override string Name
        {
            get { return "Nouveau matériel"; }
        }
    }
}
