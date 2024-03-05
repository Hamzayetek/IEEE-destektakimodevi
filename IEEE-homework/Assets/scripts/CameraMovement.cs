using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private FixedJoystick fixedjoystick;
    public float sensitivity = 400f;
    public Transform player;

    private float mouseX;
    private float mouseY;
    private float xRotation = 0f;

    

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        //mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        //mouseX = Input.GetAxis("RightStickX") * sensitivity * Time.deltaTime;
        //mouseY = Input.GetAxis("RightStickY") * sensitivity * Time.deltaTime;
        mouseX = fixedjoystick.Horizontal;
        mouseY = fixedjoystick.Vertical;


        //transform.localRotation = Quaternion.Euler(mouseY, mouseX, 0f);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
        
    }

    public void kamerayýdurdur()
    {
        sensitivity = 0f;
    }



}