using System;
using Runtime.Gameplay.Attachment;
using UnityEngine;

namespace Runtime.Gameplay.Weapon
{
    public class Weapon : IAttachable
    {
        public bool IsAttached => _isAttached;
        public float AttachmentRadius { get; }

        private Transform _parent;
        private Vector3 _offset;
        private bool _isAttached;

        public Weapon(float attachmentRadius)
        {
            AttachmentRadius = attachmentRadius;
        }
        public event Action<IAttachable> OnAttached;
        
        public void Attach(Transform parent, Vector3 offset)
        {
            _parent = parent;
            _offset = offset;
            _isAttached = true;
        }


        public Vector3 GetAttachedPosition =>
            _parent.position + _offset;
    }
}