using UnityEngine;

namespace Runtime.Gameplay.Enemies
{
    public class Enemy
    {
        public Vector3 Position;
        public Transform Target;
        public float Speed = 3f;

        public void Move(float deltaTime)
        {
            var direction = (Target.position - Position).normalized;
            Position += direction * Speed * deltaTime;
        }
    }
}