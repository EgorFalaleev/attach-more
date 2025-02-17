using Runtime.Gameplay.Attachment.Collisions;
using Runtime.Gameplay.Attachment.Provider;
using Runtime.Gameplay.Attachment.Tree;
using UnityEngine;

namespace Runtime.Gameplay.Attachment
{
    public class AttachmentController 
    {
        private AttachableTree _attachableTree;
        private readonly IAttachableCollisionsRegistry _attachableCollisionsRegistry;
        private readonly IAttachableProvider _attachableProvider;

        public AttachmentController(IAttachableCollisionsRegistry attachableCollisionsRegistry, IAttachableProvider attachableProvider)
        {
            _attachableCollisionsRegistry = attachableCollisionsRegistry;
            _attachableProvider = attachableProvider;

            _attachableCollisionsRegistry.OnValidAttachCollision += PerformAttachment;
        }

        private void PerformAttachment(IAttachableView parent, IAttachableView child)
        {
            if (!TryFindValidAttachOffset(parent, child, out var childOffset)) 
                return;

            if (_attachableTree == null)
            {
                var root = new AttachableNode();
                _attachableTree = new AttachableTree();
                _attachableTree.AddRoot(root, parent);
            }
            var parentNode = _attachableTree.FindNodeByAttachable(parent);
            var childNode = new AttachableNode();
            parentNode.AddChild(childNode);
            child.Attach(parent.Transform, childOffset);
            _attachableTree.AddToDictionaries(childNode, child);
        }
        
        private bool TryFindValidAttachOffset(IAttachableView parent, IAttachableView child, out Vector3 childOffset)
        {
            var direction = child.Transform.position - parent.Transform.position;
            var parentSize = parent.AttachmentRadius;
            var childSize = child.AttachmentRadius;
            childOffset = direction.normalized * (parentSize + childSize);
            var potentialChildPosition = parent.Transform.position + childOffset;

            var positionFound = false;
            var maxAttempts = 36;
            var rotationStep = 360f / maxAttempts;
            var currentAttempt = 0;

            // search for an offset with the same radius but different angle
            while (!positionFound && currentAttempt < maxAttempts)
            {
                var isPositionValid = true;
                
                foreach (var attachable in _attachableProvider.Attachables)
                {
                    if (attachable == child)
                        continue;

                    var distanceSqr = (potentialChildPosition - attachable.Transform.position).sqrMagnitude;
                    var minDistance = childSize + attachable.AttachmentRadius;
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