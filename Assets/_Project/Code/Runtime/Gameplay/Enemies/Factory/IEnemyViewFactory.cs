namespace Runtime.Gameplay.Enemies.Factory
{
    public interface IEnemyViewFactory
    {
        EnemyView CreateView(Enemy enemy);
    }
}