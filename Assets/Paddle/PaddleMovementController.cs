using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleMovementController : MonoBehaviour
{
    private InputSystem_Actions _inputActions;
    [SerializeField] private Vector2 _movement;
    [SerializeField] private Collider _leftBoundaryCollider;
    private float _leftBoundary;
    [SerializeField] private Collider _rightBoundaryCollider;
    private float _rightBoundary;
    private Collider _paddleCollider;
    private Camera _mainCamera;

    private void Awake()
    {
        _inputActions = new InputSystem_Actions();
        _mainCamera = Camera.main;
        _paddleCollider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        var paddleSize = _paddleCollider.bounds.size;

        _leftBoundary = _leftBoundaryCollider.bounds.max.x + paddleSize.x / 2;
        _rightBoundary = _rightBoundaryCollider.bounds.min.x - paddleSize.x / 2;
    }

    private void OnEnable()
    {
        _inputActions.Paddle.Enable();
        _inputActions.Paddle.Movement.performed += OnMovePaddle;
        _inputActions.Paddle.Movement.canceled += OnMovePaddle;
    }

    private void OnDisable()
    {
        _inputActions.Paddle.Movement.performed -= OnMovePaddle;
        _inputActions.Paddle.Movement.canceled -= OnMovePaddle;
        _inputActions.Paddle.Disable();
    }

    private void OnMovePaddle(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
        if (context.control.device is Mouse || context.control.device is Touchscreen)
        {
            var mouseWorldPosition = _mainCamera.ScreenToWorldPoint(new Vector3(_movement.x, _movement.y, -_mainCamera.transform.position.z));
            var position = transform.position;
            position.x = Mathf.Clamp(mouseWorldPosition.x, _leftBoundary, _rightBoundary);
            transform.position = position;
            _movement = Vector2.zero;
        }
    }
}
