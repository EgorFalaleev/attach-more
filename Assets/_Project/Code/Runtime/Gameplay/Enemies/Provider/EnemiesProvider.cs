using System.Collections.Generic;

namespace Runtime.Gameplay.Enemies.Provider
{
    public class EnemiesProvider : IEnemiesProvider
    {
        private List<Enemy> _enemies = new();

        public IReadOnlyList<Enemy> Enemies => _enemies;

        public void AddEnemy(Enemy enemy) =>
            _enemies.Add(enemy);

        public void RemoveEnemy(Enemy enemy) =>
            _enemies.Remove(enemy);
    }
}