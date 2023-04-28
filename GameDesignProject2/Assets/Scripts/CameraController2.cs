using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2 : MonoBehaviour
{
    public Transform playerTransform;
    public float cameraDistance = 4.0f;
    public float cameraHeight = 3.0f;
    public float cameraRotationSpeed = 1.0f;

    private float currentRotation = 0.0f;

    // Update is called once per frame
    void LateUpdate()
    {
        // Calculate the camera's position based on the player's position and cameraDistance and cameraHeight
        Vector3 cameraPosition = playerTransform.position - transform.forward * cameraDistance + Vector3.up * cameraHeight;
        transform.position = cameraPosition;

        // Rotate the camera based on mouse movements
        currentRotation += Input.GetAxis("Mouse X") * cameraRotationSpeed;
        Quaternion cameraRotation = Quaternion.Euler(25f, currentRotation, 0.0f);
        transform.rotation = cameraRotation;
    }
}
