using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Runtime.Gameplay.Weapon.Factory
{
    public class WeaponFactory : IWeaponFactory
    {
        private readonly WeaponView _weaponView;

        public event Action<WeaponView> OnWeaponCreated; 

        public WeaponFactory(WeaponView weaponView)
        {
            _weaponView = weaponView;
        }
        
        public void CreateWeapon(Vector3 position)
        {
            var weapon = Object.Instantiate(_weaponView, position, Quaternion.identity);
            
            OnWeaponCreated?.Invoke(weapon);
        }
    }
}