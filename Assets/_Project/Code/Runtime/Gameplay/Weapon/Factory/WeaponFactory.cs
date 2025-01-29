using UnityEngine;

namespace Runtime.Gameplay.Weapon.Factory
{
    public class WeaponFactory : IWeaponFactory
    {
        private readonly WeaponView _weaponView;

        public WeaponFactory(WeaponView weaponView)
        {
            _weaponView = weaponView;
            CreateWeapon(new Vector3(4.5f, 1f, 3.5f));
        }
        
        public void CreateWeapon(Vector3 position)
        {
            Object.Instantiate(_weaponView, position, Quaternion.identity);
        }
    }
}