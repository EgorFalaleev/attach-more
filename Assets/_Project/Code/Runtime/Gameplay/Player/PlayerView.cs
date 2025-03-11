using Cysharp.Threading.Tasks;
using Runtime.Gameplay.Attachment;
using UnityEngine;

namespace Runtime.Gameplay.Player
{
    public class PlayerView : MonoBehaviour, IAttachableView
    {
        [SerializeField] private AttachZone _attachZone;

        public float AttachmentRadius => _attachZone.Radius;
        public Transform Transform => transform;
        public bool IsAttached { get; set; }

        private Player _player;

        public void Initialize(Player player)
        {
            _player = player;
            IsAttached = true;
        }

        private void Update()
        {
            var moveDirection = _player.GetMovementDirection();
            if (moveDirection != Vector3.zero)
                Move(moveDirection * Time.deltaTime);
        }

        public async UniTask Attach(Transform parent, Vector3 offset)
        {
            
        }

        private void Move(Vector3 direction)
        {
            transform.Translate(direction);
        }

    }
}