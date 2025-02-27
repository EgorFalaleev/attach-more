using System;
using UnityEngine;

namespace Runtime.Gameplay.Weapon.Factory
{
    public interface IWeaponFactory
    {
        WeaponView CreateWeapon(Vector3 position);
        event Action<WeaponView> OnWeaponCreated;
    }
}