using System.Collections.Generic;

namespace Runtime.Gameplay.Attachment.Tree
{
    public class AttachableTree
    {
        private readonly AttachableNode _root;
        
        private readonly Dictionary<AttachableNode,IAttachable> _nodeToAttachable;
        private readonly Dictionary<IAttachable,AttachableNode> _attachableToNode;
        
        public AttachableNode Root => _root;
        
        public AttachableTree(AttachableNode root, IAttachable rootView)
        {
            _root = root;
            _nodeToAttachable = new Dictionary<AttachableNode, IAttachable>();
            _attachableToNode = new Dictionary<IAttachable, AttachableNode>();

            AddToDictionaries(_root, rootView);
        }

        public void AddToDictionaries(AttachableNode node, IAttachable view)
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

        public void RemoveAttachable(IAttachable attachable)
        {
            if (attachable == null)
                return;

            var node = FindNodeByAttachable(attachable);
            RemoveFromDictionaries(node, attachable);
            
            foreach (var child in node.Children)
            {
                RemoveNode(child);
            }
            
            RemoveNodeFromParentList(node);
        }

        public IAttachable FindAttachableByNode(AttachableNode node)
        {
            _nodeToAttachable.TryGetValue(node, out var attachable);
            return attachable;
        }

        public AttachableNode FindNodeByAttachable(IAttachable attachable)
        {
            _attachableToNode.TryGetValue(attachable, out var node);
            return node;
        }

        private void RemoveFromDictionaries(AttachableNode node, IAttachable attachable)
        {
            _nodeToAttachable.Remove(node);
            _attachableToNode.Remove(attachable);
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