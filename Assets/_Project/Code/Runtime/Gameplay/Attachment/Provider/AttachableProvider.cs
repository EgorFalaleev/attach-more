using System.Collections.Generic;
using Runtime.Gameplay.Weapons.Factory;

namespace Runtime.Gameplay.Attachment.Provider
{
    public class AttachableProvider : IAttachableProvider
    {
        private readonly List<IAttachableView> _attachables = new();

        public IEnumerable<IAttachableView> Attachables => _attachables;
        
        public AttachableProvider(IWeaponFactory weaponFactory)
        {
            weaponFactory.OnWeaponCreated += AddAttachable;
        }

        public void AddAttachable(IAttachableView attachableView) => 
            _attachables.Add(attachableView);

        public void RemoveAttachable(IAttachableView attachableView) =>
            _attachables.Remove(attachableView);
    }
}