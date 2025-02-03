using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Gameplay.Attachment.Tree
{
    public class AttachableNode
    {
        private readonly List<AttachableNode> _children;

        private Vector3 _offset;
        private IAttachable _view;
        
        public AttachableNode(IAttachable view, Vector3 offset)
        {
            _children = new List<AttachableNode>();
            
            _view = view;
            _offset = offset;
        }

        public void AddChild(AttachableNode child)
        {
            _children.Add(child);
        }
    }
}