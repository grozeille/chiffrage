using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chiffrage.Mvc.Events
{
    public static class ButtonEventSource
    {
        public static void RegisterBouttonClickEventSource(this IEventBroker eventBroker, Button button, IEvent myEvent)
        {
            button.Click += (sender, e) => eventBroker.Publish(myEvent);
        }
    }
}