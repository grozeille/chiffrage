using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Mvc.Events
{
    public class ErrorEvent
    {
        public Exception Exception { get; private set; }

        public ErrorEvent(Exception exception)
        {
            this.Exception = exception;
        }
    }
}
