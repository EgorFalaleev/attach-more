using System.Collections.Generic;

namespace Runtime.Gameplay.Enemies.Provider
{
    public interface IEnemiesProvider
    {
        IReadOnlyList<Enemy> Enemies { get; }
        void AddEnemy(Enemy enemy);
        void RemoveEnemy(Enemy enemy);
    }
}