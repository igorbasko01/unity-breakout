using Common;
using UnityEngine;

public class BallMovementController : MonoBehaviour
{
    private float _initialSpeed = 10f;
    [SerializeField] private float _speed = 10f;
    private Vector3 _initialDirection = new Vector3(1, 1, 0).normalized;
    private Vector3 _direction;
    private IStickable _currentStickable;
    private Collider _currentStickableCollider;

    public void Reset()
    {
        _direction = _initialDirection;
        _speed = _initialSpeed;
    }

    private void OnEnable()
    {
        Reset();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (HandleStickinessEnter(other)) return;
        HandleBounce(other);
    }

    private void OnTriggerExit(Collider other)
    {
        HandleStickinessExit(other);   
    }

    private bool HandleStickinessEnter(Collider other)
    {
        var stickable = other.GetComponent<IStickable>();
        if (stickable != null && stickable.IsSticky)
        {
            _currentStickable = stickable;
            _currentStickable.OnStickyChanged += OnStickyChanged;
            _currentStickableCollider = other;
            StickTo(other.transform);
            return true;
        }
        return false;
    }

    private void HandleStickinessExit(Collider other)
    {
        var stickable = other.GetComponent<IStickable>();
        if (stickable != null && stickable == _currentStickable)
        {
            _currentStickable.OnStickyChanged -= OnStickyChanged;
            _currentStickable = null;
            _currentStickableCollider = null;
        }
    }

    private void HandleBounce(Collider other)
    {
        Vector3 collisionNormal = (other.ClosestPoint(transform.position) - transform.position).normalized;
        
        _direction = Vector3.Reflect(_direction, collisionNormal);

        // Slighly move the ball to prevent it from getting stuck in the wall
        transform.position += _direction * 0.01f;
    }

    private void OnStickyChanged(bool isSticky)
    {
        if (!isSticky)
        {
            ReleaseStickiness();
        }
    }

    private void StickTo(Transform stickableTransform)
    {
        transform.SetParent(stickableTransform);
        _speed = 0f;
    }

    private void ReleaseStickiness()
    {
        transform.SetParent(null);
        _speed = 10f;
        HandleBounce(_currentStickableCollider);
    }

    private void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }
}
