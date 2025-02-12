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

            if (!TryFindValidAttachOffset(parent, child, out var childOffset)) 
                return;
            
            var childNode = new AttachableNode(childOffset);
            parentNode.AddChild(childNode);
            child.Attach(parent.Transform, childOffset);
            _attachableTree.AddToDictionaries(childNode, child);
        }
        
        private bool TryFindValidAttachOffset(IAttachable parent, IAttachable child, out Vector3 childOffset)
        {
            var direction = child.Transform.position - parent.Transform.position;
            var parentSize = parent.AttachZone.Radius;
            var childSize = child.AttachZone.Radius;
            childOffset = direction.normalized * (parentSize + childSize);
            var potentialChildPosition = parent.Transform.position + childOffset;

            var positionFound = false;
            var maxAttempts = 36;
            var rotationStep = 360f / maxAttempts;
            var currentAttempt = 0;

            while (!positionFound && currentAttempt < maxAttempts)
            {
                var isPositionValid = true;
                
                foreach (var attachable in _attachableProvider.Attachables)
                {
                    if (attachable == child)
                        continue;

                    var distanceSqr = (potentialChildPosition - attachable.Transform.position).sqrMagnitude;
                    var minDistance = childSize + attachable.AttachZone.Radius;
                    if (distanceSqr < minDistance * minDistance - 0.001f)
                    {
                        isPositionValid = false;
                        break;
                    }
                }

                if (isPositionValid)
                    positionFound = true;
                else
                {
                    childOffset = Quaternion.Euler(0, rotationStep, 0) * childOffset;
                    potentialChildPosition = parent.Transform.position + childOffset;
                    currentAttempt++;
                }
            }

            return positionFound;
        }
    }
}