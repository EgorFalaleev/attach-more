using System;
using Runtime.Gameplay.Attachment;
using Runtime.Services;
using UnityEngine;
using Zenject;

namespace Runtime.Gameplay.Player
{
    public class PlayerView : MonoBehaviour, IAttachable
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private AttachZone _attachZone;
        
        private IInputService _inputService;

        // player can not be attached to anything
        public bool IsAttached => false;
        
        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Update()
        {
            if (_inputService.MoveDirection != Vector3.zero)
                Move(_inputService.MoveDirection * (_speed * Time.deltaTime));
        }

        private void Move(Vector3 direction)
        {
            transform.Translate(direction);
        }

    }
}