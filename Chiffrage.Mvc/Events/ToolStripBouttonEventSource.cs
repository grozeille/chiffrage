using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chiffrage.Mvc.Events
{
    public static class ToolStripBouttonEventSource
    {
        public static void RegisterToolStripBouttonClickEventSource(this IEventBroker eventBroker, ToolStripButton button, IEvent myEvent)
        {
            button.Click += (sender, e) => eventBroker.Publish(myEvent);
        }
    }
}
