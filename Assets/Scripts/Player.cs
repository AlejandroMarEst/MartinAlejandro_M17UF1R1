using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Player : Character, InputSystem_Actions.IPlayerActions
{
    private InputSystem_Actions inputAction;
    private Vector2 input;
    private void Awake()
    {
        base.Awake();
        inputAction = new InputSystem_Actions();
        inputAction.Player.SetCallbacks(this);
    }

    void FixedUpdate()
    {
        _mb.MoveCharacter(input);
    }

    private void OnEnable()
    {
        inputAction.Enable();
    }
    private void OnDisable()
    {
        inputAction.Disable();
    }

    // OnUserInput

    public void OnInteract(InputAction.CallbackContext context)
    {
        _mb.FlipGravity();
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        _mb.Jump();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }
    public void StopPlayer()
    {
        inputAction.Disable();
    }
    public void ResumePlayer()
    {
        inputAction.Enable();
    }
}
