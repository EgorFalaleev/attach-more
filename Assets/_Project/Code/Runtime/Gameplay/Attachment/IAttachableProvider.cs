using System.Collections.Generic;

namespace Runtime.Gameplay.Attachment
{
    public interface IAttachableProvider
    {
        IReadOnlyList<IAttachable> Attachables { get; }
    }
}