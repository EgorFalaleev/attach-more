using UnityEngine;

namespace Runtime.Gameplay.Enemies
{
    public class Enemy
    {
        public Vector3 Position;
        public Vector3 TargetPosition;
        public float Speed = 3f;

        public void Move(float deltaTime)
        {
            var direction = (TargetPosition - Position).normalized;
            Position += direction * Speed * deltaTime;
        }
    }
}