---
id: TASK-1
title: Create sticky paddle
created: 2024-12-21 22:40:04
priority: Medium
category: Feature
owner: 
board: Backlog
---

## Description
The idea here is just to create the functionality of the stickines, just for the start of the game.
The `IStickable` interface:
```csharp
public interface IStickable
{
    bool IsSticky { get; }
    event System.Action<bool> OnStickinessChanged; // Event to notify stickiness state changes
}
```

The `StickyPaddle` implementation of `IStickable`:
```csharp
using UnityEngine;

public class StickyPaddle : MonoBehaviour, IStickable
{
    private bool isSticky = true;

    public bool IsSticky
    {
        get => isSticky;
        private set
        {
            if (isSticky != value)
            {
                isSticky = value;
                OnStickinessChanged?.Invoke(isSticky); // Notify listeners
            }
        }
    }

    public event System.Action<bool> OnStickinessChanged;

    // Implement un stickiness by pressing LMB, Touch tap or Space key. Use New Input System.
}
```

Ball logic implementation for stickeness:
```csharp
using UnityEngine;

public class Ball : MonoBehaviour
{
    // TODO: Verify if we really need the Rigidbody.
    private Rigidbody rb;
    private IStickable currentStickable;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var stickable = other.GetComponent<IStickable>();
        if (stickable != null && stickable.IsSticky)
        {
            currentStickable = stickable;
            currentStickable.OnStickinessChanged += HandleStickinessChanged;

            StickTo(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var stickable = other.GetComponent<IStickable>();
        if (stickable == currentStickable)
        {
            currentStickable.OnStickinessChanged -= HandleStickinessChanged;
            currentStickable = null;
        }
    }

    private void HandleStickinessChanged(bool isSticky)
    {
        if (!isSticky)
        {
            Release();
        }
    }

    private void StickTo(Transform paddleTransform)
    {
        // TODO: Possibly should not use Rigidbody, as the movement is manual position setting.
        rb.velocity = Vector2.zero;
        rb.isKinematic = true; // Prevent physics interference
        transform.SetParent(paddleTransform); // Attach to the paddle
    }

    private void Release()
    {
        // TODO: Again, not sure that I need to Rigidbody because the movement is manual.
        rb.isKinematic = false;
        transform.SetParent(null);

        // Example: Set an initial release velocity
        rb.velocity = new Vector2(1, 1).normalized * 5f; // Adjust as needed
    }
}
```

The basic approach is as follows:
- [ ] Create IStickable interface.
- [ ] Create MonoBehaviour that implements the IStickable interface. It is stickable only until fired.
- [ ] Attach this MonoBehaviour to the paddle.
- [ ] This MonoBehaviour maybe should implement un sticking by listennig to input.
- [ ] Create input action for LMB, Touch tap, and Keyboard Space, that will disable the stickiness.

## Notes


## History
2024-12-21 22:40:04 - Created
