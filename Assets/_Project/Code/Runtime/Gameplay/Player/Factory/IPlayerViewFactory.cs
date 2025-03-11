using System;
using UnityEngine;

namespace Runtime.Gameplay.Player.Factory
{
    public interface IPlayerViewFactory
    {
        PlayerView CreatePlayerView(Player player, Vector3 spawnPosition);
        event Action<PlayerView> OnPlayerViewCreated;
    }
}