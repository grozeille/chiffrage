using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.App.ViewModel;
using Chiffrage.Mvc.Views;

namespace Chiffrage.App.Views
{
    public interface IErrorLogView: IView
    {
        void AppendLog(LogItemViewModel logItem);
    }
}
