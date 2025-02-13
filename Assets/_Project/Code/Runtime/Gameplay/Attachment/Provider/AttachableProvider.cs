using System.Collections.Generic;
using Runtime.Gameplay.Player;
using Runtime.Gameplay.Weapon.Factory;

namespace Runtime.Gameplay.Attachment.Provider
{
    public class AttachableProvider : IAttachableProvider
    {
        private readonly IWeaponFactory _weaponFactory;
        private readonly List<IAttachableView> _attachables = new();

        public IEnumerable<IAttachableView> Attachables => _attachables;
        
        public AttachableProvider(IWeaponFactory weaponFactory, PlayerView playerView)
        {
            _weaponFactory = weaponFactory;
            weaponFactory.OnWeaponCreated += AddAttachable;
            
            _attachables.Add(playerView);
        }

        private void AddAttachable(IAttachableView attachableView) => 
            _attachables.Add(attachableView);
    }
}