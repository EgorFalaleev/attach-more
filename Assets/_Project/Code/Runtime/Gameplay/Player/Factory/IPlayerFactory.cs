using UnityEngine;

namespace Runtime.Gameplay.Player.Factory
{
    public interface IPlayerFactory
    {
        void CreatePlayer(Vector3 position);
    }
}