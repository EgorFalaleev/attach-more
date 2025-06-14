using System.Collections.Generic;
using Runtime.Gameplay.Weapons.Factory;

namespace Runtime.Gameplay.Attachment.Provider
{
    public class AttachableProvider : IAttachableProvider
    {
        private readonly List<IAttachable> _attachables = new();

        public IEnumerable<IAttachable> Attachables => _attachables;
        
        public AttachableProvider(IWeaponFactory weaponFactory)
        {
            weaponFactory.OnWeaponCreated += AddAttachable;
        }

        public void AddAttachable(IAttachable attachable) => 
            _attachables.Add(attachable);

        public void RemoveAttachable(IAttachable attachable) =>
            _attachables.Remove(attachable);
    }
}