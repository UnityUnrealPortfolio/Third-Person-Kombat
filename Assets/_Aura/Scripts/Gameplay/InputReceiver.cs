using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputReceiver : MonoBehaviour, PlayerInputActions.IPlayerActions
{
    public event Action OnJumpEvent;
    public event Action OnDodgeEvent;
    public event Action<Vector2> OnMoveEvent;

    private PlayerInputActions playerInputActions;
    private void Start()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.SetCallbacks(this);

        playerInputActions.Player.Enable();
    }
    private void OnDestroy()
    {
        playerInputActions.Player.Disable();

    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed) { OnJumpEvent?.Invoke(); }
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (context.performed) { OnDodgeEvent?.Invoke(); }

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        
            OnMoveEvent?.Invoke(context.ReadValue<Vector2>());
        
    }
}
