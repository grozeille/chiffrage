using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Mvc.Views
{
    public class WizardSettingListIterator : IWizardSettingIterator
    {
        private readonly IList<WizardSetting> settings;

        private int position = 0;

        public WizardSettingListIterator(params WizardSetting[] settings)
        {
            this.settings = settings;
        }

        public WizardSettingListIterator(List<WizardSetting> settings)
        {
            this.settings = settings;
        }

        public WizardSetting Current
        {
            get { return this.settings[this.position]; }
        }

        public bool MoveNext()
        {
            if (this.IsLast)
                return false;

            this.position++;
            return true;
        }
        
        public bool MovePrevious()
        {
            if (this.IsFirst)
                return false;

            this.position--;
            return true;
        }

        public bool IsLast
        {
            get { return this.position == settings.Count-1; }
        }

        public bool IsFirst
        {
            get { return this.position == 0; }
        }


        public void Reset()
        {
            this.position = 0;
        }
    }
}
