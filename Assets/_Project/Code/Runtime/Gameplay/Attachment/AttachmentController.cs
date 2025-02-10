using Runtime.Gameplay.Attachment.Tree;
using Runtime.Gameplay.Player;
using Runtime.Services.Collisions;
using UnityEngine;

namespace Runtime.Gameplay.Attachment
{
    public class AttachmentController 
    {
        private readonly AttachableTree _attachableTree;
        private readonly IAttachableCollisionsRegistry _attachableCollisionsRegistry;

        public AttachmentController(PlayerView playerView, IAttachableCollisionsRegistry attachableCollisionsRegistry)
        {
            _attachableCollisionsRegistry = attachableCollisionsRegistry;

            var root = new AttachableNode(Vector3.zero);
            _attachableTree = new AttachableTree(root, playerView);

            _attachableCollisionsRegistry.OnValidAttachCollision += PerformAttachment;
        }

        private void PerformAttachment(IAttachable parent, IAttachable child)
        {
            var parentNode = _attachableTree.FindNodeByAttachable(parent);
            var childNode = new AttachableNode(Vector3.zero);
            parentNode.AddChild(childNode);

            var direction = child.Transform.position - parent.Transform.position;
            var parentSize = parent.AttachZone.Radius;
            var childSize = child.AttachZone.Radius;
            
            child.Attach(parent.Transform, direction.normalized * (parentSize + childSize));
            _attachableTree.AddToDictionaries(childNode, child);
        }
    }
}