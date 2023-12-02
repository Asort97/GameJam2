using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class HeadBobController : MonoBehaviour
{
    [SerializeField] private bool bobbingIsEnable;
    [SerializeField, Range(0, 0.1f)] private float amplitudeY = 0.015f;
    [SerializeField, Range(0, 0.1f)] private float amplitudeX = 0.015f;
    [SerializeField, Range(0, 30f)] private float frequency = 10f;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Transform cameraHolder;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Rigidbody rb;
    private float toggleSpeed = 1.0f;
    private int frequencyTime;
    private Vector3 startPos;

    private void Start()
    {
        startPos = playerCamera.localPosition;
        ResetPosition();
    }
    // Update is called once per frame
    private void Update()
    {
        if(bobbingIsEnable) return;

        CheckMotion();
        ResetPosition();
        playerCamera.LookAt(FocusTarget());
    }
    private void CheckMotion()
    {
        float speed = new Vector3(rb.velocity.x, 0, rb.velocity.z).magnitude;

        if(speed <= toggleSpeed) return;
        if(!playerController.isGrounded()) return;

        PlayMotion(FootStepMotion());
    }
    
    private Vector3 FootStepMotion()
    {
        Vector3 pos = Vector3.zero;
        pos += Camera.main.transform.up * Mathf.Sin(Time.time * frequency) * amplitudeY;
        pos += Camera.main.transform.right * Mathf.Cos(Time.time * frequency / 2) * amplitudeX * 2;
        return pos;
    }

    private void PlayMotion(Vector3 motion)
    {        
        playerCamera.position += motion;             
    }

    private void ResetPosition()
    {
        if(playerCamera.localPosition == startPos) return;

        playerCamera.localPosition = Vector3.Lerp(playerCamera.localPosition, startPos, 1* Time.deltaTime);
    }

    private Vector3 FocusTarget()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + cameraHolder.localPosition.y, transform.position.z);
        pos += cameraHolder.forward * 15.0f;
        return pos;
    }
}
