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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        noise = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.H) && isGrounded)
        {
            Debug.Log("JUMPED");
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;

            if(!isPlaying)
            {
                isPlaying = true;
            }
        }
        if(isPlaying)
        {
            noise.Play();
            Debug.Log("It works");
            isPlaying = false;

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }
    }
}
