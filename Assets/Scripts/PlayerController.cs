using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float speed;
    [SerializeField] private float forceJump;
    [SerializeField] private Transform groundedPoint;
    [SerializeField] private Transform body;
    [SerializeField] private Transform gunHandler;
    [SerializeField] private float smoothRotateHandler;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float raduisGrounded;
    [SerializeField] private Camera playerCamera;
    private Rigidbody rb;
    private InputManager inputManager;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
        inputManager = InputManager.Instance;
    }

    private void Update()
    {
        RotateGunHandler();
        Jump();
        Movement();
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
