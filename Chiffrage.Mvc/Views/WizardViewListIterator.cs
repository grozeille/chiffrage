using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Mvc.Views
{
    public class WizardViewListIterator : IWizardSettingIterator
    {
        private readonly IList<WizardView> wizards;

        private GenericWizardSetting<WizardPage> wizardSetting;

        private WizardView currentWizard = null;

        public WizardViewListIterator(params WizardView[] wizards)
        {
            this.wizards = wizards;
            this.wizardSetting = new GenericWizardSetting<WizardPage>("Sélection de l'assitant", "Sélection de l'assitant", false);

            this.wizardSetting.TypedPage.Wizards = this.wizards;            
        }

        public WizardViewListIterator(IList<WizardView> wizards)
        {
            this.wizards = wizards;
            this.wizardSetting = new GenericWizardSetting<WizardPage>("Sélection de l'assitant", "Sélection de l'assitant", false);

            this.wizardSetting.TypedPage.Wizards = this.wizards;
        }

        public WizardSetting Current
        {
            get 
            {
                if (currentWizard == null)
                {
                    return this.wizardSetting;
                }
                else
                {
                    return currentWizard.WizardSettingIterator.Current;
                }
            }
        }

        public bool MoveNext()
        {
            if (currentWizard == null)
            {
                // get the selected wizard, and start it
                currentWizard = this.wizardSetting.TypedPage.Selected;
                if (currentWizard != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return currentWizard.WizardSettingIterator.MoveNext();
            }
        }

        public bool MovePrevious()
        {
            if (currentWizard == null)
            {
                return false;
            }
            else
            {
                if (currentWizard.WizardSettingIterator.IsFirst)
                {
                    currentWizard = null;
                    return true;
                }
                else 
                {
                    return currentWizard.WizardSettingIterator.MovePrevious();
                }                
            }
        }

        public bool IsLast
        {
            get 
            {
                if (currentWizard == null)
                {
                    return false;
                }
                else
                {
                    return currentWizard.WizardSettingIterator.IsLast;
                }
            }
        }

        public bool IsFirst
        {
            get
            {
                if (currentWizard == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void Reset()
        {
            this.currentWizard = null;
        }
    }
}
