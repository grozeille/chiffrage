﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiffrage.Mvc.Events
{
    public interface IEventHandlerOnUI<T>
    {
        void ProcessAction(T eventObject);
    }
}
