using System.Collections.Generic;
using Runtime.Gameplay.Attachment.Tree;
using Runtime.Gameplay.Player;
using Runtime.Gameplay.Weapon;
using Runtime.Gameplay.Weapon.Factory;
using Runtime.Services.Collisions;
using UnityEngine;

namespace Runtime.Gameplay.Attachment
{
    public class AttachmentController 
    {
        private readonly PlayerView _playerView;
        private readonly List<WeaponView> _weapons;
        private readonly IWeaponFactory _weaponFactory;
        private readonly AttachableTree _attachableTree;
        private readonly IAttachableCollisionsRegistry _attachableCollisionsRegistry;

        public AttachmentController(PlayerView playerView, IWeaponFactory weaponFactory, IAttachableCollisionsRegistry attachableCollisionsRegistry)
        {
            _playerView = playerView;
            _weaponFactory = weaponFactory;
            _attachableCollisionsRegistry = attachableCollisionsRegistry;

            _weapons = new List<WeaponView>();
            var root = new AttachableNode(Vector3.zero);
            _attachableTree = new AttachableTree(root, _playerView);

            _attachableCollisionsRegistry.OnValidAttachCollision += AddTreeNode;
        }

        private void AddTreeNode(IAttachable parent, IAttachable child)
        {
            var parentNode = _attachableTree.FindNodeByAttachable(parent);
            var childNode = new AttachableNode(Vector3.zero);
            parentNode.AddChild(childNode);
            
            _attachableTree.AddToDictionaries(parentNode, parent);
            _attachableTree.AddToDictionaries(childNode, child);
        }
    }
}