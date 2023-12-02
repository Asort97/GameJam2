using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float forceJump;
    [SerializeField] private Transform groundedPoint;
    [SerializeField] private Transform body;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float raduisGrounded;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform playerBody;
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
        Movement();
        Jump();
        RotateBody();
    }

    private void Movement()
    {
        if(inputManager)
        {
            Vector2 movement = inputManager.GetPlayerMovement();
            if(movement.x != 0f || movement.y != 0f)
            {
                Vector3 move = playerCamera.transform.TransformDirection(new Vector3(movement.x, 0f, movement.y));

                transform.Translate(new Vector3(move.x, 0f, move.z) * speed * Time.deltaTime);
                playerBody.transform.eulerAngles = new Vector3(0f, playerCamera.transform.eulerAngles.y, 0f);              
            }            
        }
    }

    private void RotateBody()
    {
        // Получаем направление от объекта камеры
        Vector3 directionToCamera = Camera.main.transform.position - body.position;

        // Вычисляем целевую кватернионную ротацию
        Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);

        // Плавно поворачиваем капсулу в направлении камеры
        body.rotation = Quaternion.Lerp(body.rotation, targetRotation, 3f * Time.deltaTime);
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
