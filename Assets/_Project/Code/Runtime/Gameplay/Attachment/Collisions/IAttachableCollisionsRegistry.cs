using System;

namespace Runtime.Gameplay.Attachment.Collisions
{
    public interface IAttachableCollisionsRegistry
    {
        event Action<IAttachableView, IAttachableView> OnValidAttachCollision;
    }
}