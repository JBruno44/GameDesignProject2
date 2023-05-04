using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStabilizer : MonoBehaviour
{
    public Transform target;
    public float smoothing = 0.5f;
    public float jitterThreshold = 0.1f;
    public float maxStabilizationSpeed = 10f;

    private Vector3 previousPosition;
    private Vector3 velocity;

    void Start()
    {
        previousPosition = transform.position;
    }

    void LateUpdate()
    {
        // Calculate the current velocity of the camera based on its current and previous positions
        velocity = (transform.position - previousPosition) / Time.deltaTime;

        // Check if the camera's velocity is below the jitter threshold, and stabilize it if necessary
        if (velocity.magnitude < jitterThreshold)
        {
            // Calculate the target position for the camera, using the previous position as a reference point
            Vector3 targetPosition = target.position + (transform.position - previousPosition);

            // Smoothly move the camera towards the target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime * maxStabilizationSpeed);
        }

        // Store the current position of the camera for use in the next frame
        previousPosition = transform.position;
    }
}






