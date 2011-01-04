using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Mvc.Views
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class BeginInvokeAttribute : Attribute
    {
    }
}
