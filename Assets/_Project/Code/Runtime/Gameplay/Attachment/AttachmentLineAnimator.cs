using System;
using System.Collections;
using UnityEngine;

namespace Runtime.Gameplay.Attachment
{
    [RequireComponent(typeof(LineRenderer))]
    public class AttachmentLineAnimator : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private float _animationDuration = 1f;

        public void AnimateLine(Transform startPoint, Transform endPoint)
        {
            _lineRenderer.positionCount = 2;
            _lineRenderer.SetPosition(0, startPoint.position);
            _lineRenderer.SetPosition(1, startPoint.position);

            StartCoroutine(AnimateLineSmoothly(startPoint, endPoint));
        }

        private IEnumerator AnimateLineSmoothly(Transform startPoint, Transform endPoint)
        {
            var elapsedTime = 0f;

            while (elapsedTime < _animationDuration)
            {
                var delta = elapsedTime / _animationDuration;

                _lineRenderer.SetPosition(0, startPoint.position);
                var newPosition = Vector3.Lerp(startPoint.position, endPoint.position, delta);
                _lineRenderer.SetPosition(1, newPosition);

                elapsedTime += Time.deltaTime;

                yield return null;
            }
            
            _lineRenderer.SetPosition(1, endPoint.position);

            while (true)
            {
                _lineRenderer.SetPosition(0, startPoint.position);
                _lineRenderer.SetPosition(1, endPoint.position);
                yield return null;
            }
        }
    }
}