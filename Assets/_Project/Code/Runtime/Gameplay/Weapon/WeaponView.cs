using System;
using Runtime.Gameplay.Attachment;
using UnityEngine;

namespace Runtime.Gameplay.Weapon
{
    public class WeaponView : MonoBehaviour, IAttachable
    {
        [SerializeField] private AttachZone _weaponAttachZone;
        public AttachZone AttachZone => _weaponAttachZone;

        public bool IsAttached { get; }

        public event Action<IAttachable, IAttachable> OnWeaponReadyToAttach; 
        
        private void OnEnable()
        {
            _weaponAttachZone.AttachableInRange += PrepareWeaponForAttaching;
        }

        private void PrepareWeaponForAttaching(IAttachable attachable)
        {
            OnWeaponReadyToAttach?.Invoke(this, attachable);
        }
    }
}