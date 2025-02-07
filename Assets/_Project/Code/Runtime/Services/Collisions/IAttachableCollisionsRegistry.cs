using System;
using Runtime.Gameplay.Attachment;

namespace Runtime.Services.Collisions
{
    public interface IAttachableCollisionsRegistry
    {
        event Action<IAttachable, IAttachable> OnValidAttachCollision;
    }
}