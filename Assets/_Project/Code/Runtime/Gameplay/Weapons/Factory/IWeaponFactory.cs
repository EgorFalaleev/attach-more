using System;
using UnityEngine;

namespace Runtime.Gameplay.Weapons.Factory
{
    public interface IWeaponFactory
    {
        Weapon CreateWeapon(Vector3 position);
        event Action<Weapon> OnWeaponCreated;
    }
}