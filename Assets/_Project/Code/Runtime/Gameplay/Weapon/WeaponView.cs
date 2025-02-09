using System;
using Cysharp.Threading.Tasks;
using Runtime.Gameplay.Attachment;
using UnityEngine;

namespace Runtime.Gameplay.Weapon
{
    public class WeaponView : MonoBehaviour, IAttachable
    {
        [SerializeField] private AttachZone _weaponAttachZone;
        [SerializeField] private AttachmentLineAnimator _attachmentLineAnimator;

        private bool _isAttached;
        private bool _canMove;
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
            if (!_canMove)
                return;

            transform.position = _parent.position + _offset;
        }
        
        public async UniTaskVoid Attach(Transform parent, Vector3 offset)
        {
            _parent = parent;
            _offset = offset;
            _isAttached = true;
            
            await _attachmentLineAnimator.AnimateLineAsync(parent, transform);
            await MoveTowardsAttachedPositionAsync(1f);

            _canMove = true;
        }

        private void PrepareWeaponForAttaching(IAttachable attachable)
        {
            OnWeaponAttachedOtherAttachable?.Invoke(this, attachable);
        }

        private async UniTask MoveTowardsAttachedPositionAsync(float duration)
        {
            var elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                var delta = elapsedTime / duration;
                
                transform.position = Vector3.Lerp(transform.position, _parent.position + _offset, delta);

                elapsedTime += Time.deltaTime;

                await UniTask.Yield();
            }

            transform.position = _parent.position + _offset;
        }
    }
}