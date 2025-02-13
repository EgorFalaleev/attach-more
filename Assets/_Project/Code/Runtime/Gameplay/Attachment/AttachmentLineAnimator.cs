using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Runtime.Gameplay.Attachment
{
    [RequireComponent(typeof(LineRenderer))]
    public class AttachmentLineAnimator : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private float _animationDuration = 1f;

        private Transform _lineStartPoint;
        private Transform _lineEndPoint;
        private bool _animationFinished;

        private void Update()
        {
            if (!_animationFinished)
                return;
            
            _lineRenderer.SetPosition(0, _lineStartPoint.position);
            _lineRenderer.SetPosition(1, _lineEndPoint.position);
        }

        public async UniTask AnimateLineAsync(Transform startPoint, Transform endPoint)
        {
            _lineStartPoint = startPoint;
            _lineEndPoint = endPoint;
            
            _lineRenderer.positionCount = 2;
            _lineRenderer.SetPosition(0, startPoint.position);
            _lineRenderer.SetPosition(1, startPoint.position);

            var elapsedTime = 0f;

            while (elapsedTime < _animationDuration)
            {
                var delta = elapsedTime / _animationDuration;

                _lineRenderer.SetPosition(0, startPoint.position);
                var newPosition = Vector3.Lerp(startPoint.position, endPoint.position, delta);
                _lineRenderer.SetPosition(1, newPosition);

                elapsedTime += Time.deltaTime;

                await UniTask.Yield();
            }
            
            _lineRenderer.SetPosition(1, endPoint.position);

            _animationFinished = true;
        }
    }
}