using Cysharp.Threading.Tasks;
using Runtime.Gameplay.Attachment;
using Runtime.Services.Input;
using UnityEngine;
using Zenject;

namespace Runtime.Gameplay.Player
{
    public class PlayerView : MonoBehaviour, IAttachableView
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private AttachZone _attachZone;

        public float AttachmentRadius => _attachZone.Radius;
        public Transform Transform => transform;
        public bool IsAttached { get; set; }
        
        private IInputService _inputService;
        
        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
            IsAttached = true;
        }

        private void Update()
        {
            if (_inputService.MoveDirection != Vector3.zero)
                Move(_inputService.MoveDirection * (_speed * Time.deltaTime));
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