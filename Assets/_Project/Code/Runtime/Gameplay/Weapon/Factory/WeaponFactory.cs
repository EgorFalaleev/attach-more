using System;
using UnityEngine;
using Zenject;

namespace Runtime.Gameplay.Weapon.Factory
{
    public class WeaponFactory : IWeaponFactory
    {
        private readonly WeaponView _weaponView;
        private readonly IInstantiator _instantiator;

        public event Action<WeaponView> OnWeaponCreated; 

        public WeaponFactory(WeaponView weaponView, IInstantiator instantiator)
        {
            _weaponView = weaponView;
            _instantiator = instantiator;
        }
        
        public void CreateWeapon(Vector3 position)
        {
            var weapon =
                _instantiator.InstantiatePrefabForComponent<WeaponView>(_weaponView, position, Quaternion.identity, null);
            
            OnWeaponCreated?.Invoke(weapon);
        }
    }
}