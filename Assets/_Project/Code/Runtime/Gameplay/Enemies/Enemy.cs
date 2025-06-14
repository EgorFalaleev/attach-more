using UnityEngine;

namespace Runtime.Gameplay.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _speed = 3f;
        private Transform _target;

        public void Initialize(Transform target)
        {
            _target = target;
        }

        private void Update()
        {
            var direction = (_target.position - transform.position).normalized;
            Move(direction);
        }

        private void Move(Vector3 direction) => 
            transform.Translate(direction * (_speed * Time.deltaTime));
    }
}