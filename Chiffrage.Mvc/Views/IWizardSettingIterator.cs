using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Mvc.Views
{
    public interface IWizardSettingIterator
    {
        WizardSetting Current { get; }

        bool MoveNext();

        bool MovePrevious();

        bool IsLast { get; }

        bool IsFirst { get; }

        void Reset();
    }
}
