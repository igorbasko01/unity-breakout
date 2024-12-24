using UnityEngine;

[RequireComponent(typeof(BallOutOfBoundsController))]
[RequireComponent(typeof(BallMovementController))]
public class BallSpawningController : MonoBehaviour
{
    [SerializeField] private Vector3 _spawnPosition;
    private BallOutOfBoundsController _ballOutOfBoundsController;
    private BallMovementController _ballMovementController;
    
    void OnEnable()
    {
        _ballOutOfBoundsController = GetComponent<BallOutOfBoundsController>();
        _ballMovementController = GetComponent<BallMovementController>();
        _ballOutOfBoundsController.OnBallOutOfBounds += OnBallOutOfBounds;
        _spawnPosition = transform.position;
    }

    private void OnBallOutOfBounds()
    {
        transform.position = _spawnPosition;
        _ballMovementController.Reset();
    }

    void OnDisable()
    {
        _ballOutOfBoundsController.OnBallOutOfBounds -= OnBallOutOfBounds;
    }
}
