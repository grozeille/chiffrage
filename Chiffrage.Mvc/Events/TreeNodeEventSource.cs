using System.Windows.Forms;

namespace Chiffrage.Mvc.Events
{
    public static class TreeNodeEventSource
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
    }
}