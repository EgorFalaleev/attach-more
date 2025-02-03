using System;
using UnityEngine;

namespace Runtime.Gameplay.Attachment
{
    [RequireComponent(typeof(Collider))]
    public class AttachZone : MonoBehaviour
    {
        private bool _isActive;
        
        public event Action<AttachZone> AttachableInRange;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out AttachZone attachZone) && _isActive)
            {
                AttachableInRange?.Invoke(attachZone);
            }
        }

        public void ActivateZone()
        {
            _isActive = true;
        }
    }
}