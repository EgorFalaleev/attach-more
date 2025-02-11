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
        private readonly IAttachableProvider _attachableProvider;

        public AttachmentController(PlayerView playerView, IAttachableCollisionsRegistry attachableCollisionsRegistry, IAttachableProvider attachableProvider)
        {
            _attachableCollisionsRegistry = attachableCollisionsRegistry;
            _attachableProvider = attachableProvider;

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
            var potentialChildOffset = direction.normalized * (parentSize + childSize);
            var potentialChildPosition = parent.Transform.position + potentialChildOffset;
            
            foreach (var attachable in _attachableProvider.Attachables)
            {
                if (attachable == child)
                    continue;

                var distanceSqr = (potentialChildPosition - attachable.Transform.position).sqrMagnitude;
                if (distanceSqr < childSize + attachable.AttachZone.Radius)
                    Debug.Log("Incorrect position");
            }
            
            child.Attach(parent.Transform, potentialChildOffset);
            _attachableTree.AddToDictionaries(childNode, child);
        }
    }
}