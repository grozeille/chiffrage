using System;
using System.Windows.Forms;

namespace Chiffrage.Mvc.Events
{
    public static class WinformEventSource
    {
        public static void RegisterTreeNodeSelectEventSource(this IEventBroker eventBroker, TreeNode treeNode,
                                                             IEvent myEvent)
        {
            treeNode.TreeView.AfterSelect += (sender, e) =>
                                             {
                                                 if (e.Node == treeNode)
                                                     eventBroker.Publish(myEvent);
                                             };
        }

        public static void RegisterTreeNodeUnselectEventSource(this IEventBroker eventBroker, TreeNode treeNode,
                                                               IEvent myEvent)
        {
            treeNode.TreeView.BeforeSelect += (sender, e) =>
                                              {
                                                  if (e.Node != treeNode)
                                                      eventBroker.Publish(myEvent);
                                              };
        }

        public static void RegisterBouttonClickEventSource(this IEventBroker eventBroker, Button button, IEvent myEvent)
        {
            button.Click += (sender, e) => eventBroker.Publish(myEvent);
        }

        public static void RegisterToolStripBouttonClickEventSource(this IEventBroker eventBroker, ToolStripButton button, IEvent myEvent)
        {
            button.Click += (sender, e) => eventBroker.Publish(myEvent);
        }

        public static void RegisterToolStripMenuItemClickEventSource(this IEventBroker eventBroker, ToolStripMenuItem item, IEvent myEvent)
        {
            item.Click += (sender, e) => eventBroker.Publish(myEvent);
        }

        public static void RegisterToolStripMenuItemClickEventSource(this IEventBroker eventBroker, ToolStripMenuItem item, Func<IEvent> eventFunction)
        {
            item.Click += (sender, e) =>
            {
                var myEvent = eventFunction();
                if (myEvent != null)
                {
                    eventBroker.Publish(myEvent);
                }
            };
        }
    }
}