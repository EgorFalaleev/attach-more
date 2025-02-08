using System;
using Runtime.Gameplay.Attachment;
using UnityEngine;

namespace Runtime.Gameplay.Weapon
{
    public class WeaponView : MonoBehaviour, IAttachable
    {
        [SerializeField] private AttachZone _weaponAttachZone;

        private bool _isAttached;
        private Vector3 _offset;
        private Transform _parent;

        public Transform Transform => transform;
        public AttachZone AttachZone => _weaponAttachZone;
        public bool IsAttached => _isAttached;

        public event Action<IAttachable, IAttachable> OnWeaponAttachedOtherAttachable;

        private void OnEnable()
        {
            _weaponAttachZone.AttachableInRange += PrepareWeaponForAttaching;
        }

        private void Update()
        {
            if (!_isAttached)
                return;

            transform.position = _parent.position + _offset;
        }


        public void Attach(Transform parent, Vector3 offset)
        {
            _isAttached = true;
            _parent = parent;
            _offset = offset;
        }

        private void PrepareWeaponForAttaching(IAttachable attachable)
        {
            OnWeaponAttachedOtherAttachable?.Invoke(this, attachable);
        }
    }
}