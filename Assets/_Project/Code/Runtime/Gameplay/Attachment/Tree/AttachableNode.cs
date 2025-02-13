using System.Collections.Generic;

namespace Runtime.Gameplay.Attachment.Tree
{
    public class AttachableNode
    {
        private readonly List<AttachableNode> _children = new();

        public IEnumerable<AttachableNode> Children => _children;

        public void AddChild(AttachableNode child) => 
            _children.Add(child);

        public void RemoveChild(AttachableNode child) =>
            _children.Remove(child);
    }
}