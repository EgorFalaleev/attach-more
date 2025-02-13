using System;
using Runtime.Gameplay.Weapon;
using Runtime.Gameplay.Weapon.Factory;

namespace Runtime.Gameplay.Attachment.Collisions
{
    public class AttachableCollisionsRegistry : IAttachableCollisionsRegistry
    {
        private readonly IWeaponFactory _weaponFactory;

        public event Action<IAttachableView, IAttachableView> OnValidAttachCollision; 
        
        public AttachableCollisionsRegistry(IWeaponFactory weaponFactory)
        {
            _weaponFactory = weaponFactory;

            _weaponFactory.OnWeaponCreated += RegisterWeapon;
        }

        private void RegisterWeapon(WeaponView weaponView)
        {
            weaponView.OnWeaponAttachedOtherAttachable += CheckValidAttachment ;
        }

        private void CheckValidAttachment(IAttachableView attachable1, IAttachableView attachable2)
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