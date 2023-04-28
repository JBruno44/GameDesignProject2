using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMovementJR : MonoBehaviour
{
    public Camera playerCamera;
    public float moveSpeed = 5.0f;

    private bool isMovingForward = false;
    private bool isMovingBackward = false;
    private bool isMovingLeft = false;
    private bool isMovingRight = false;

    void Update()
    {
        // Get the forward direction of the camera
        Vector3 cameraForward = playerCamera.transform.forward;
        cameraForward.y = 0.0f;
        cameraForward.Normalize();

        // Get the right direction of the camera
        Vector3 cameraRight = playerCamera.transform.right;
        cameraRight.y = 0.0f;
        cameraRight.Normalize();

        // Check if the WASD keys are pressed
        if (Input.GetKeyDown(KeyCode.W))
        {
            isMovingForward = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            isMovingBackward = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            isMovingLeft = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            isMovingRight = true;
        }

        // Check if the WASD keys are released
        if (Input.GetKeyUp(KeyCode.W))
        {
            isMovingForward = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            isMovingBackward = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            isMovingLeft = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            isMovingRight = false;
        }

        // Move the player based on the WASD keys
        Vector3 movementDirection = Vector3.zero;
        if (isMovingForward)
        {
            movementDirection += cameraForward;
        }
        if (isMovingBackward)
        {
            movementDirection -= cameraForward;
        }
        if (isMovingLeft)
        {
            movementDirection -= cameraRight;
        }
        if (isMovingRight)
        {
            movementDirection += cameraRight;
        }
        movementDirection.Normalize();

        transform.position += movementDirection * moveSpeed * Time.deltaTime;
    }
}

