using System;
using UnityEngine;

namespace Runtime.Gameplay.Attachment
{
    [RequireComponent(typeof(Collider))]
    public class AttachZone : MonoBehaviour
    {
        public event Action<IAttachable> AttachableInRange;
        
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(nameof(OnTriggerEnter));
            if (other.TryGetComponent(out AttachZone attachZone))
            {
                var otherAttachable = other.GetComponentInParent<IAttachable>();
                AttachableInRange?.Invoke(otherAttachable);
            }
        }
    }
}