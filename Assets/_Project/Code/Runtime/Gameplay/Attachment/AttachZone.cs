using System;
using UnityEngine;

namespace Runtime.Gameplay.Attachment
{
    [RequireComponent(typeof(Collider))]
    public class AttachZone : MonoBehaviour
    {
        public event Action<AttachZone> OnAttachableInRange;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out AttachZone attachZone))
            {
                OnAttachableInRange?.Invoke(attachZone);
            }
        }
    }
}