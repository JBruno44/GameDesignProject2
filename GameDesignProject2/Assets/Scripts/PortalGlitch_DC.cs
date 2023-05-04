using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGlitch_DC : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector4 color;
    private Renderer glitch;
    void Start()
    {
        glitch = GetComponent<Renderer>();
        color = new Vector4(.7f, 0f, .7f, 1f);
        glitch.material.SetFloat("_TintColor", .7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
