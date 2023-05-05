using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_DC : MonoBehaviour
{
    // Start is called before the first frame update
    float rotation = 0;
    Renderer rotating;
    void Start()
    {
        rotating = GetComponent<Renderer>();
        rotating.material.SetFloat("_Rotation", rotation);

    }

    // Update is called once per frame
    void Update()
    {
        rotation += 37.9f;
        rotating.material.SetFloat("_Rotation", rotation);
    }
}
