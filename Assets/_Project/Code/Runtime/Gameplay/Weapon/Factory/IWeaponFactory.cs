using System;
using UnityEngine;

namespace Runtime.Gameplay.Weapon.Factory
{
    public interface IWeaponFactory
    {
        void CreateWeapon(Vector3 position);
        event Action<WeaponView> OnWeaponCreated;
    }
}