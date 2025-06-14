using System.Collections.Generic;

namespace Runtime.Gameplay.Attachment.Provider
{
    public interface IAttachableProvider
    {
        IEnumerable<IAttachable> Attachables { get; }
        void AddAttachable(IAttachable attachable);
        void RemoveAttachable(IAttachable attachable);
    }
}