using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chiffrage.Mvc.Events;

namespace Chiffrage.App.Events
{
    public class ApplicationLoadedEvent
    {
        public int Position { get; private set; }
        public int Max { get; private set; }
        public string Status { get; private set; }

        public ApplicationLoadedEvent(int position, int max, string status)
        {
            Position = position;
            Max = max;
            Status = status;
        }
    }
}
