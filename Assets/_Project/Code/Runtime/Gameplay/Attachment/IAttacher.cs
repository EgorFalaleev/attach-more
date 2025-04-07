using UnityEngine;

namespace Runtime.Gameplay.Attachment
{
    public interface IAttacher
    {
        void Attach(IAttachable attachable, Vector3 offset);
    }
}