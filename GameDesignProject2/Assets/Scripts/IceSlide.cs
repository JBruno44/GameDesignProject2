using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSlide : MonoBehaviour
{
    public string iceTag = "Ice";
    public float slideSpeed = 5f;
    public float iceFriction = 0.1f;
    private Vector3 lastPosition;
    private bool isOnIce;

    void Start()
    {
        lastPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (isOnIce)
        {
            Vector3 moveDirection = transform.position - lastPosition;
            lastPosition = transform.position;
            float slideFactor = 1f;
            if (moveDirection.magnitude > 0.01f)
            {
                slideFactor = Vector3.Dot(moveDirection.normalized, transform.forward);
            }
            Vector3 slideDirection = Vector3.Cross(transform.up, moveDirection.normalized);
            float slideMagnitude = slideSpeed * slideFactor * iceFriction;
            Vector3 slideForce = slideMagnitude * slideDirection;
            GetComponent<Rigidbody>().AddForce(slideForce);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(iceTag))
        {
            isOnIce = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(iceTag))
        {
            isOnIce = false;
        }
    }
}
