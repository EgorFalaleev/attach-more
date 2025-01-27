using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Runtime.Services
{
    public class InputService : IInputService
    {
        private PlayerInput _playerInput;
        private InputAction _moveAction;

        private Vector3 _moveDirection;

        public Vector3 MoveDirection => _moveDirection;
        
        public InputService()
        {
            _playerInput = new PlayerInput();

            _moveAction = _playerInput.Player.Move;
            Enable();
        }

        public void Enable()
        {
            _playerInput.Enable();

            _moveAction.performed += OnMovePerformed;
            _moveAction.canceled += OnMoveCanceled;
        }

        public void Disable()
        {
            _playerInput.Disable();

            _moveAction.performed -= OnMovePerformed;
            _moveAction.canceled -= OnMoveCanceled;
        }

        private void OnMovePerformed(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>().normalized;
            _moveDirection = new Vector3(direction.x, 0f, direction.y);
        }

        private void OnMoveCanceled(InputAction.CallbackContext obj)
        {
            _moveDirection = Vector3.zero;
        }
    }
}