using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping_DC : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 dir;
    public float jumpForce = 7.0f;
    public bool isGrounded = true;
    public float maxHeight = 50f;
    private AudioSource noise;
    private bool isPlaying = false;
    private Rigidbody rb;
    private float jumpCooldown = 0.2f; // added variable for jump cooldown
    private float lastJumpTime = -Mathf.Infinity; // initialize to negative infinity to allow immediate jump

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        noise = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.H) && isGrounded && Time.time - lastJumpTime > jumpCooldown) // added cooldown check
        {
            Debug.Log("JUMPED");
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
<<<<<<< HEAD
            isGrounded = false;

            if(!isPlaying)
=======
            lastJumpTime = Time.time; // update last jump time
            if (!isPlaying)
>>>>>>> 34b76ec0838108ae4dd030605b7a08cca6e26a9d
            {
                isPlaying = true;
            }
        }
        if (isPlaying)
        {
            noise.Play();
            Debug.Log("It works");
            isPlaying = false;

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Ice")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Ice")
        {
            isGrounded = false;
        }
    }
}
