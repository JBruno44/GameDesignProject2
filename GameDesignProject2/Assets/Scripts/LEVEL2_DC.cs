using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LEVEL2_DC : MonoBehaviour
{
    // Start is called before the first frame update

    public GAME_DC manager;

    //use this to get to the next level.

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        manager.storeLives();
    }
}
