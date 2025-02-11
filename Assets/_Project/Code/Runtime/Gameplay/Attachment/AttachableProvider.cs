using System.Collections.Generic;
using Runtime.Gameplay.Player;
using Runtime.Gameplay.Weapon.Factory;

namespace Runtime.Gameplay.Attachment
{
    public class AttachableProvider : IAttachableProvider
    {
        private readonly IWeaponFactory _weaponFactory;
        private readonly List<IAttachable> _attachables = new();

        public IReadOnlyList<IAttachable> Attachables => _attachables;
        
        public AttachableProvider(IWeaponFactory weaponFactory, PlayerView playerView)
        {
            _weaponFactory = weaponFactory;
            weaponFactory.OnWeaponCreated += AddAttachable;
            
            _attachables.Add(playerView);
        }

        private void AddAttachable(IAttachable attachable) => 
            _attachables.Add(attachable);
    }
}