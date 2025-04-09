using System;
using Runtime.Constants;
using Runtime.Infrastructure.Assets;
using UnityEngine;
using Zenject;

namespace Runtime.Gameplay.Weapons.Factory
{
    public class WeaponFactory : IWeaponFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;

        public event Action<Weapon> OnWeaponCreated; 

        public WeaponFactory(IAssetProvider assetProvider, IInstantiator instantiator)
        {
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }
        
        public Weapon CreateWeapon(Vector3 position)
        {
            var prefab = _assetProvider.Load<Weapon>(Paths.Weapon);
            var weapon = _instantiator.InstantiatePrefabForComponent<Weapon>(prefab, position, Quaternion.identity, null);
            
            OnWeaponCreated?.Invoke(weapon);
            return weapon;
        }
    }
}