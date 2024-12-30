using UnityEngine;

namespace Common
{
    [RequireComponent(typeof(Collider))]
    public class BounceDirectionChanger : MonoBehaviour, IDirectionChanger
    {
        private Collider _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
        }

        public Vector3 CalculateNewDirection(Vector3 originalPosition, Vector3 originalDirection)
        {
            Vector3 normal = (_collider.ClosestPoint(originalPosition) - originalPosition).normalized;
            Vector3 reflectedDirection = Vector3.Reflect(originalDirection, normal);
            return reflectedDirection.normalized;
        }
    }
}
