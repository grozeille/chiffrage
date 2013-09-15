using System;
using System.Windows.Forms;
using Common.Logging;

namespace Chiffrage.Mvc.Events
{
    public static class WinformEventSource
    {
        private static ILog logger = LogManager.GetLogger(typeof(WinformEventSource));

        public static void RegisterTreeNodeSelectEventSource(this IEventBroker eventBroker, TreeNode treeNode,
                                                             object myEvent, string topic)
        {
            treeNode.TreeView.AfterSelect += (sender, e) =>
                                             {
                                                 if (e.Node == treeNode)
                                                     eventBroker.Publish(myEvent, topic);
                                             };
        }

        public static void RegisterTreeNodeUnselectEventSource(this IEventBroker eventBroker, TreeNode treeNode,
                                                               object myEvent, string topic)
        {
            treeNode.TreeView.BeforeSelect += (sender, e) =>
                                              {
                                                  if (e.Node != treeNode)
                                                      eventBroker.Publish(myEvent, topic);
                                              };
        }

        public static void RegisterBouttonClickEventSource(this IEventBroker eventBroker, Button button, object myEvent, string topic)
        {
            button.Click += (sender, e) => eventBroker.Publish(myEvent, topic);
        }

        public static void RegisterToolStripBouttonClickEventSource(this IEventBroker eventBroker, ToolStripButton button, object myEvent, string topic)
        {
            button.Click += (sender, e) => eventBroker.Publish(myEvent, topic);
        }

        public static void RegisterToolStripBouttonClickEventSource(this IEventBroker eventBroker, ToolStripButton button, Func<object> eventFunction, string topic)
        {
            button.Click += (sender, e) =>
            {
                var myEvent = eventFunction();
                if (myEvent != null)
                {
                    eventBroker.Publish(myEvent, topic);
                }
            };
        }

        public static void RegisterToolStripMenuItemClickEventSource(this IEventBroker eventBroker, ToolStripMenuItem item, object myEvent, string topic)
        {
            item.Click += (sender, e) => eventBroker.Publish(myEvent, topic);
        }

        public static void RegisterToolStripMenuItemClickEventSource(this IEventBroker eventBroker, ToolStripMenuItem item, Func<object> eventFunction, string topic)
        {
            item.Click += (sender, e) =>
            {
                var myEvent = eventFunction();
                if (myEvent != null)
                {
                    eventBroker.Publish(myEvent, topic);
                }
            };
        }
    }
}