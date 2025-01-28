using System.Collections.Generic;
using Runtime.Gameplay.Player;
using UnityEngine;
using Zenject;

namespace Runtime.Gameplay.Attachment
{
    public class AttachmentController : IInitializable
    {
        private PlayerView _playerView;
        private List<IAttachable> _attachables;

        public void Initialize()
        {
            _playerView = Object.FindObjectOfType<PlayerView>();
        }
    }
}