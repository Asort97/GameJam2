using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float actionDistance;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float speed;
    [SerializeField] private float forceJump;
    [SerializeField] private float smoothLerpToCrouch;
    [SerializeField] private float crouchForce;
    [SerializeField] private Transform cameraHolder;
    [SerializeField] private Transform groundedPoint;
    [SerializeField] private Transform body;
    [SerializeField] private Transform gunHandler;
    [SerializeField] private float smoothRotateHandler;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float raduisGrounded;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Vector3 startPosCamera;
    [SerializeField] private float startHeightCollider;
    private CapsuleCollider capsuleCollider;
    private Rigidbody rb;
    private InputManager inputManager;

    public bool canMove = true;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        inputManager = InputManager.Instance;
        
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        
        startHeightCollider = capsuleCollider.height;
        startPosCamera = cameraHolder.localPosition;
    }

    private void Update()
    {
        if(canMove)
        {
            RotateGunHandler();
            // Jump();
            // Crouch();
            Movement();
            Interact();            
        }
    }

    private void Movement()
    {
        if(inputManager)
        {
            Vector2 movement = inputManager.GetPlayerMovement();
            if(movement.x != 0f || movement.y != 0f)
            {

                Vector3 move = playerCamera.transform.TransformDirection(new Vector3(movement.x, 0f, movement.y)) * speed;
                
                rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);

                // playerBody.transform.eulerAngles = new Vector3(0f, playerCamera.transform.eulerAngles.y, 0f);              
            }
            else
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
            }
        }
    }

    private void RotateGunHandler()
    {
        gunHandler.rotation = Quaternion.Slerp(gunHandler.rotation, playerCamera.transform.rotation, smoothRotateHandler * Time.deltaTime);
    }

    private void Jump()
    {
        if(inputManager)
        {
            if(inputManager.PlayerJumpedThisFrame() && isGrounded())
            {
                rb.AddForce(Vector3.up * forceJump, ForceMode.Impulse);
            }
        }
    }

    private void Interact()
    {
        if(inputManager.PlayerAction())
        {
            RaycastHit hitInfo;

            Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            Vector3 direction = Camera.main.transform.TransformDirection(Vector3.forward);

            if (Physics.Raycast(pos, direction, out hitInfo, actionDistance))
            {
                if(hitInfo.transform.TryGetComponent<ItemObject>(out ItemObject itemObject))
                {
                    itemObject.Interaction();
                }
            }
            InputManager.Instance.PlayerAction();            
        }
    }

    private void Crouch()
    {
        if(inputManager)
        {
            if(inputManager.PlayerCrouchThisFrame())
            {
                cameraHolder.position = Vector3.Lerp(cameraHolder.position, new Vector3(cameraHolder.position.x ,cameraHolder.position.y / crouchForce , cameraHolder.position.z), smoothLerpToCrouch * Time.deltaTime);
                capsuleCollider.height = startHeightCollider / 1.5f;
            }
            else
            {
                cameraHolder.position = Vector3.Lerp(cameraHolder.position, new Vector3(cameraHolder.position.x, startPosCamera.y, cameraHolder.position.z), smoothLerpToCrouch * Time.deltaTime);
                capsuleCollider.height = startHeightCollider;
            }
        }
    }

    public bool isGrounded()
    {
        Collider[] grounds = Physics.OverlapSphere(groundedPoint.position, raduisGrounded, groundLayer);

        if(grounds.Length != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Attack()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundedPoint.position, raduisGrounded);
    }
}
