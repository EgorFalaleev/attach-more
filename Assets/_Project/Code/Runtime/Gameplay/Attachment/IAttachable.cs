using UnityEngine;

namespace Runtime.Gameplay.Attachment
{
    public interface IAttachable
    {
        bool IsAttached { get; }
        float AttachmentRadius { get; }
        void Attach(Transform parent, Vector3 offset);
    }
}