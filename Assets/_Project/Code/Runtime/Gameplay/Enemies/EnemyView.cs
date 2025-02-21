using UnityEngine;

namespace Runtime.Gameplay.Enemies
{
    public class EnemyView : MonoBehaviour
    {
        private Enemy _enemy;

        public void Initialize(Enemy enemy)
        {
            _enemy = enemy;
        }

        private void Update()
        {
            transform.position = _enemy.Position;
        }
    }
}