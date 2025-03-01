using System.Collections.Generic;

namespace Runtime.Gameplay.Attachment.Provider
{
    public interface IAttachableProvider
    {
        IEnumerable<IAttachableView> Attachables { get; }
        void AddAttachable(IAttachableView attachableView);
        void RemoveAttachable(IAttachableView attachableView);
    }
}