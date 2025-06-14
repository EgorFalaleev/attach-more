using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Runtime.Gameplay.Attachment
{
    public interface IAttachable
    {
        Transform Transform { get; }
        UniTask Attach(Transform parent, Vector3 offset);
        bool IsAttached { get; }
        float AttachmentRadius { get; }
    }
}