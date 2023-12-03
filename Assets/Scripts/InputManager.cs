using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance
    {
        get
        {
            return instance;
        }
    }
    private PlayerControls playerControls;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        playerControls = new PlayerControls();
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return playerControls.Player.Movement.ReadValue<Vector2>();
    }
    public Vector2 GetMouseDelta()
    {
        return playerControls.Player.Look.ReadValue<Vector2>();
    }
    public bool PlayerJumpedThisFrame()
    {
        return playerControls.Player.Jump.triggered;
    }
    public bool PlayerCrouchThisFrame()
    {
        return playerControls.Player.Crouch.IsPressed();
    }
    public bool PlayerAction()
    {
        return playerControls.Player.Action.triggered;
    }
    public bool PlayerLeftMouse()
    {
        return playerControls.Player.Mouse0.triggered;
    }
    public bool PlayerRightMouse()
    {
        return playerControls.Player.Mouse1.triggered;
    }
}
