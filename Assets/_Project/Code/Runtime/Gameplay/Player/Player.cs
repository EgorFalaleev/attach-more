using Runtime.Services.Input;
using UnityEngine;

namespace Runtime.Gameplay.Player
{
    public class Player
    {
        private readonly IInputService _inputService;
        private float _speed;

        public Player(IInputService inputService, float speed)
        {
            _inputService = inputService;
            _speed = speed;
        }

        public Vector3 GetMovementDirection() =>
            _inputService.MoveDirection * _speed;
    }
}