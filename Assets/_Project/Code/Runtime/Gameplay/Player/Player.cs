using Cysharp.Threading.Tasks;
using Runtime.Gameplay.Attachment;
using Runtime.Services.Input;
using UnityEngine;
using Zenject;

namespace Runtime.Gameplay.Player
{
    public class Player : MonoBehaviour, IAttachable
    {
        [SerializeField] private float _speed;
        [SerializeField] private AttachZone _attachZone;

        private IInputService _inputService;

        public Transform Transform => transform;
        public bool IsAttached => true;
        public float AttachmentRadius => _attachZone.Radius;
        
        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }
        
        private void Update()
        {
            Move(_inputService.MoveDirection * (_speed * Time.deltaTime));
        }

        private void Move(Vector3 direction)
        {
            if (direction != Vector3.zero)
                transform.Translate(direction);
        }

        public async UniTask Attach(Transform parent, Vector3 offset)
        {
            
        }
    }
}