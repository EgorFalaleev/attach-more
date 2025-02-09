using Cysharp.Threading.Tasks;
using Runtime.Gameplay.Attachment;
using Runtime.Services.Input;
using UnityEngine;
using Zenject;

namespace Runtime.Gameplay.Player
{
    public class PlayerView : MonoBehaviour, IAttachable
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private AttachZone _attachZone;
        public AttachZone AttachZone => _attachZone;
        
        private IInputService _inputService;

        public Transform Transform => transform;

        public async UniTaskVoid Attach(Transform parent, Vector3 offset)
        {
            
        }

        public bool IsAttached { get; set; }
        
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

        private void Move(Vector3 direction)
        {
            transform.Translate(direction);
        }

    }
}