using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Gameplay.Attachment.Tree
{
    public class AttachableNode
    {
        private readonly List<AttachableNode> _children;

        private Vector3 _offset;

        public IReadOnlyList<AttachableNode> Children => _children;
        
        public AttachableNode(IAttachable view, Vector3 offset)
        {
            _children = new List<AttachableNode>();
            
            _offset = offset;
        }

        public void AddChild(AttachableNode child) => 
            _children.Add(child);

        public void RemoveChild(AttachableNode child) =>
            _children.Remove(child);
    }
}