using System;
using Runtime.Services;
using UnityEngine;
using Zenject;

namespace Runtime.Gameplay.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        
        private IInputService _inputService;

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