using System;
using UnityEngine;

public class BallOutOfBoundsController : MonoBehaviour
{
    public event Action OnBallOutOfBounds;
    [SerializeField] private Collider _boundsCollider;

    private void OnTriggerExit(Collider other)
    {
        if (other == _boundsCollider)
        {
            OnBallOutOfBounds?.Invoke();
        }
    }
}
