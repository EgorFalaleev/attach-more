using System;
using Runtime.Gameplay.Weapons;
using Runtime.Gameplay.Weapons.Factory;

namespace Runtime.Gameplay.Attachment.Collisions
{
    public class AttachableCollisionsRegistry : IAttachableCollisionsRegistry
    {
        private readonly IWeaponFactory _weaponFactory;

        public event Action<IAttachable, IAttachable> OnValidAttachCollision; 
        
        public AttachableCollisionsRegistry(IWeaponFactory weaponFactory)
        {
            _weaponFactory = weaponFactory;

            _weaponFactory.OnWeaponCreated += RegisterWeapon;
        }

        private void RegisterWeapon(Weapon weapon)
        {
            weapon.OnWeaponAttachedOtherAttachable += CheckValidAttachment ;
        }

        private void CheckValidAttachment(IAttachable attachable1, IAttachable attachable2)
        {
            if (attachable1 == null || attachable2 == null)
                return;

            var attachable1IsAttached = attachable1.IsAttached;
            var attachable2IsAttached = attachable2.IsAttached;

            if (attachable1IsAttached && attachable2IsAttached)
                return;

            if (!attachable1IsAttached && !attachable2IsAttached)
                return;

            var parent = attachable1IsAttached ? attachable1 : attachable2;
            var child = attachable1IsAttached ? attachable2 : attachable1;
            
            OnValidAttachCollision?.Invoke(parent, child);
        }
    }
}