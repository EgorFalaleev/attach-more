using System;
using UnityEngine;

namespace Runtime.Gameplay.Attachment
{
    [RequireComponent(typeof(Collider))]
    public class AttachZone : MonoBehaviour
    {
        private bool _isActive;
        
        public event Action<IAttachable> AttachableInRange;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out AttachZone attachZone))
            {
                var otherAttachable = other.GetComponentInParent<IAttachable>();
                AttachableInRange?.Invoke(otherAttachable);
            }
        }

        public void ActivateZone()
        {
            _isActive = true;
        }
    }
}