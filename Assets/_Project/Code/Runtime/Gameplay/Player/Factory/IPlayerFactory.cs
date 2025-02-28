using System;
using UnityEngine;

namespace Runtime.Gameplay.Player.Factory
{
    public interface IPlayerFactory
    {
        PlayerView CreatePlayer(Vector3 position);
        event Action<PlayerView> OnPlayerCreated;
    }
}