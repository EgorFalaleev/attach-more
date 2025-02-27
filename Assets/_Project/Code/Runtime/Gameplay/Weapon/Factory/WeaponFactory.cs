using System;
using Runtime.Constants;
using Runtime.Infrastructure.Assets;
using UnityEngine;
using Zenject;

namespace Runtime.Gameplay.Weapon.Factory
{
    public class WeaponFactory : IWeaponFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;

        public event Action<WeaponView> OnWeaponCreated; 

        public WeaponFactory(IAssetProvider assetProvider, IInstantiator instantiator)
        {
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }
        
        public WeaponView CreateWeapon(Vector3 position)
        {
            var prefab = _assetProvider.Load<WeaponView>(Paths.Weapon);
            var weapon = _instantiator.InstantiatePrefabForComponent<WeaponView>(prefab, position, Quaternion.identity, null);
            
            OnWeaponCreated?.Invoke(weapon);
            return weapon;
        }
    }
}