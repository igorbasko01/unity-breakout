using UnityEngine;

namespace Common
{
    public class RelativeBounceDirectionChanger : MonoBehaviour, IDirectionChanger
    {
        [SerializeField] private float _bounceAngleFactor = 2f;

        public Vector3 CalculateNewDirection(Vector3 originalPosition, Vector3 originalDirection)
        {
            Vector3 localPosition = transform.InverseTransformPoint(originalPosition);
            float hitPointX = localPosition.x / (transform.localScale.x / 2);
            float amplifiedHitPointX = hitPointX * _bounceAngleFactor;
            Vector3 localNewDirection = new Vector3(amplifiedHitPointX, 1, 0).normalized;
            Vector3 worldNewDirection = transform.TransformDirection(localNewDirection);
            return worldNewDirection.normalized;
        }
    }
}
