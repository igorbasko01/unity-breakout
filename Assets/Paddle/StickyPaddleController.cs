using UnityEngine;
using Common;
using System;
using UnityEngine.InputSystem;

public class StickyPaddleController : MonoBehaviour, IStickable
{
    public event Action<bool> OnStickyChanged;
    public bool IsSticky 
    {
        get => _isSticky;
        private set 
        {
            if (_isSticky != value)
            {
                _isSticky = value;
                OnStickyChanged?.Invoke(_isSticky);
            }
        }
    }

    [SerializeField] bool _keepSticky = true;

    [SerializeField] private bool _isSticky = true;
    private InputSystem_Actions _inputActions;

    private void Awake()
    {
        _inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        _inputActions.Paddle.Enable();
        _inputActions.Paddle.Action.performed += OnActionPerformed;
        _inputActions.Paddle.Action.canceled += OnActionPerformed;
    }

    private void OnActionPerformed(InputAction.CallbackContext context)
    {
        if (!IsSticky) return;
        IsSticky = false;  // Using property setter to trigger event
        IsSticky = _keepSticky;
    }

    private void OnDisable()
    {
        _inputActions.Paddle.Action.performed -= OnActionPerformed;
        _inputActions.Paddle.Action.canceled -= OnActionPerformed;
        _inputActions.Paddle.Disable();
    }
}
