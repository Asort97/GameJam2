using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private InputManager inputManager;
    private Animator playerAnimator;
    private void Start()
    {
        inputManager = InputManager.Instance;
        playerAnimator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        SetAxisMovement();
        if (inputManager.GetPlayerMovement().x != 0f || inputManager.GetPlayerMovement().y != 0f)
        {
            playerAnimator.SetBool("isMoving", true);
        }
        else
        {
            playerAnimator.SetBool("isMoving", false);
        }
    }
    private void SetAxisMovement()
    {
        playerAnimator.SetFloat("movementX", inputManager.GetPlayerMovement().x);
        playerAnimator.SetFloat("movementY", inputManager.GetPlayerMovement().y);
    }
}
