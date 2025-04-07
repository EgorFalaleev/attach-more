using System;
using UnityEngine;

namespace Runtime.Gameplay.Player.Factory
{
    public interface IPlayerFactory
    {
        Player CreatePlayer(Vector3 spawnPosition);
        event Action<Player> OnPlayerViewCreated;
    }
}