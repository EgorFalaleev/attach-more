using System;

namespace Runtime.Gameplay.Attachment
{
    public interface IAttachable
    {
        bool IsAttached { get; }
        float AttachmentRadius { get; }
        event Action<IAttacher> OnAttached;
    }
}