using System.Collections.Generic;

namespace Runtime.Gameplay.Attachment.Tree
{
    public class AttachableTree
    {
        private readonly Dictionary<AttachableNode,IAttachableView> _nodeToAttachable;
        private readonly Dictionary<IAttachableView,AttachableNode> _attachableToNode;
        
        private AttachableNode _root;
     
        public AttachableNode Root => _root;
        
        public AttachableTree()
        {
            _nodeToAttachable = new Dictionary<AttachableNode, IAttachableView>();
            _attachableToNode = new Dictionary<IAttachableView, AttachableNode>();
        }

        public void AddRoot(AttachableNode root, IAttachableView rootView)
        {
            _root = root;
            AddToDictionaries(root, rootView);
        }

        public void AddToDictionaries(AttachableNode node, IAttachableView view)
        {
            if (node == null || view == null)
                return;

            _nodeToAttachable[node] = view;
            _attachableToNode[view] = node;
        }

        public void RemoveNode(AttachableNode node)
        {
            if (node == null)
                return;

            var attachable = FindAttachableByNode(node);
            RemoveFromDictionaries(node, attachable);

            foreach (var child in node.Children)
            {
                RemoveNode(child);
            }

            RemoveNodeFromParentList(node);
        }

        public void RemoveAttachable(IAttachableView attachableView)
        {
            if (attachableView == null)
                return;

            var node = FindNodeByAttachable(attachableView);
            RemoveFromDictionaries(node, attachableView);
            
            foreach (var child in node.Children)
            {
                RemoveNode(child);
            }
            
            RemoveNodeFromParentList(node);
        }

        public IAttachableView FindAttachableByNode(AttachableNode node)
        {
            _nodeToAttachable.TryGetValue(node, out var attachable);
            return attachable;
        }

        public AttachableNode FindNodeByAttachable(IAttachableView attachableView)
        {
            _attachableToNode.TryGetValue(attachableView, out var node);
            return node;
        }

        private void RemoveFromDictionaries(AttachableNode node, IAttachableView attachableView)
        {
            _nodeToAttachable.Remove(node);
            _attachableToNode.Remove(attachableView);
        }

        private void RemoveNodeFromParentList(AttachableNode node)
        {
            var parent = FindParent(_root, node);
            if (parent != null)
                parent.RemoveChild(node);
        }

        private AttachableNode FindParent(AttachableNode currentNode, AttachableNode targetNode)
        {
            if (currentNode == null || targetNode == null)
                return null;

            foreach (var child in currentNode.Children)
            {
                if (child == targetNode)
                    return currentNode;

                var parent = FindParent(child, targetNode);
                if (parent != null)
                    return parent;
            }

            return null;
        }
    }
}