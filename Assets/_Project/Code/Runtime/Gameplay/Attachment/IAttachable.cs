using UnityEngine;

namespace Runtime.Gameplay.Attachment
{
    public interface IAttachable
    {
        Transform Transform { get; }
        void Attach(Transform parent, Vector3 offset);
        bool IsAttached { get; }
        AttachZone AttachZone { get; }
    }
}