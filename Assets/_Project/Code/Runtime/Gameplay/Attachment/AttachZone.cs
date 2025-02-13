using System;
using UnityEngine;

namespace Runtime.Gameplay.Attachment
{
    [RequireComponent(typeof(Collider))]
    public class AttachZone : MonoBehaviour
    {
        private Collider _collider;

        public float Radius => _collider.bounds.extents.x;
        public event Action<IAttachableView> AttachableInRange;

        private void Start()
        {
            _collider = GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out AttachZone attachZone))
            {
                var otherAttachable = other.GetComponentInParent<IAttachableView>();
                AttachableInRange?.Invoke(otherAttachable);
            }
        }

        private void OnDrawGizmos()
        {
            _collider = GetComponent<Collider>();
            
            Gizmos.DrawWireSphere(transform.position, Radius);
        }
    }
}