using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testJumping_JR : MonoBehaviour
{
    public float jumpForce = 5f; // The force of the jump
    public float jumpAcceleration = 3.0f;
    public float jumpDeceleration = 3.0f;
    public float maxJumpTime = .5f;
    private bool isGrounded = true;

    private Rigidbody rb;
    private float jumpTime = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpTime = 0.0f;
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            isGrounded = false;
        }

        if (rb.velocity.y > 0.0f && jumpTime < maxJumpTime)
        {
            float jumpSpeed = Mathf.Lerp(jumpForce, 0.0f, jumpTime / maxJumpTime);
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
            jumpTime += Time.deltaTime;
        }
        else if (rb.velocity.y < 0.0f)
        {
            rb.velocity += new Vector3(0.0f, Physics.gravity.y * jumpDeceleration * Time.deltaTime, 0.0f);
        }
        else
        {
            rb.velocity += new Vector3(0.0f, Physics.gravity.y * jumpAcceleration * Time.deltaTime, 0.0f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }
}