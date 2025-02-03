using System.Collections.Generic;
using Runtime.Gameplay.Attachment.Tree;
using Runtime.Gameplay.Player;
using Runtime.Gameplay.Weapon;
using Runtime.Gameplay.Weapon.Factory;
using UnityEngine;
using Zenject;

namespace Runtime.Gameplay.Attachment
{
    public class AttachmentController 
    {
        private readonly PlayerView _playerView;
        private List<WeaponView> _weapons;
        private IWeaponFactory _weaponFactory;
        private readonly AttachableTree _attachableTree;

        public AttachmentController(PlayerView playerView, IWeaponFactory weaponFactory)
        {
            _playerView = playerView;
            _weaponFactory = weaponFactory;

            _weapons = new List<WeaponView>();
            var root = new AttachableNode(_playerView, Vector3.zero);
            _attachableTree = new AttachableTree(root);
            
            _weaponFactory.OnWeaponCreated += RegisterWeapon;
        }

        private void RegisterWeapon(WeaponView weapon)
        {
            _weapons.Add(weapon);
            weapon.OnWeaponReadyToAttach += AttachWeapon;
        }

        private void AttachWeapon(WeaponView weaponView)
        {
            var weaponNode = new AttachableNode(weaponView, Vector3.zero);
            
        }
    }
}