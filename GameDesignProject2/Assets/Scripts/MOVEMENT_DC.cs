using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVEMENT_DC : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 dir;
    public float speed = 5.0f;
    void Start()
    {
        Vector3 dir = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)) {
            dir = -Vector3.left;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            dir = Vector3.left;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            dir = Vector3.forward;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            dir = -Vector3.forward;
        }
        else
        {
            dir = Vector3.zero;
        }
        this.transform.position += dir * Time.deltaTime * speed;
    }
}
