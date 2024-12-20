using UnityEngine;

public class BallMovementController : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    private Vector3 _direction;

    private void Start()
    {
        _direction = new Vector3(1, 1, 0).normalized;
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 collisionNormal = (other.ClosestPoint(transform.position) - transform.position).normalized;
        
        _direction = Vector3.Reflect(_direction, collisionNormal);

        // Slighly move the ball to prevent it from getting stuck in the wall
        transform.position += _direction * 0.01f;
    }

    private void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }
}
