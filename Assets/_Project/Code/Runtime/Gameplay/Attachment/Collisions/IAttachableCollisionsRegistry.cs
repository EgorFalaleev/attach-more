using System;

namespace Runtime.Gameplay.Attachment.Collisions
{
    public interface IAttachableCollisionsRegistry
    {
        event Action<IAttachable, IAttachable> OnValidAttachCollision;
    }
}