using System;
using System.Windows.Forms;
using Common.Logging;

namespace Chiffrage.Mvc.Events
{
    public static class WinformEventSource
    {
        private static ILog logger = LogManager.GetLogger(typeof(WinformEventSource));

        public static void RegisterTreeNodeSelectEventSource(this IEventBroker eventBroker, TreeNode treeNode,
                                                             object myEvent)
        {
            treeNode.TreeView.AfterSelect += (sender, e) =>
                                             {
                                                 if (e.Node == treeNode)
                                                     eventBroker.Publish(myEvent);
                                             };
        }

        public static void RegisterTreeNodeUnselectEventSource(this IEventBroker eventBroker, TreeNode treeNode,
                                                               object myEvent)
        {
            treeNode.TreeView.BeforeSelect += (sender, e) =>
                                              {
                                                  if (e.Node != treeNode)
                                                      eventBroker.Publish(myEvent);
                                              };
        }

        public static void RegisterBouttonClickEventSource(this IEventBroker eventBroker, Button button, object myEvent)
        {
            button.Click += (sender, e) => eventBroker.Publish(myEvent);
        }

        public static void RegisterToolStripBouttonClickEventSource(this IEventBroker eventBroker, ToolStripButton button, object myEvent)
        {
            button.Click += (sender, e) => eventBroker.Publish(myEvent);
        }

        public static void RegisterToolStripBouttonClickEventSource(this IEventBroker eventBroker, ToolStripButton button, Func<object> eventFunction)
        {
            button.Click += (sender, e) =>
            {
                var myEvent = eventFunction();
                if (myEvent != null)
                {
                    eventBroker.Publish(myEvent);
                }
            };
        }

        public static void RegisterToolStripMenuItemClickEventSource(this IEventBroker eventBroker, ToolStripMenuItem item, object myEvent)
        {
            item.Click += (sender, e) => eventBroker.Publish(myEvent);
        }

        public static void RegisterToolStripMenuItemClickEventSource(this IEventBroker eventBroker, ToolStripMenuItem item, Func<object> eventFunction)
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