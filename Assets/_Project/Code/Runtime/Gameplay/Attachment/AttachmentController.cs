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

                    var distance = (potentialChildPosition - attachable.Transform.position).magnitude;
                    if (distance < childSize + attachable.AttachZone.Radius - 0.001f)
                    {
                        Debug.Log($"Attachables are too close ({child.Transform.gameObject.name} and {attachable.Transform.gameObject.name}): distance {distance}, required {childSize + attachable.AttachZone.Radius}");
                        isPositionValid = false;
                        break;
                    }
                }

                if (isPositionValid)
                    positionFound = true;
                else
                {
                    potentialChildOffset = Quaternion.Euler(0, rotationStep, 0) * potentialChildOffset;
                    potentialChildPosition = parent.Transform.position + potentialChildOffset;
                    currentAttempt++;
                }
            }

            if (!positionFound)
            {
                Debug.Log("Could not find a valid position");
                return;
            }
            
            child.Attach(parent.Transform, potentialChildOffset);
            _attachableTree.AddToDictionaries(childNode, child);
        }
    }
}