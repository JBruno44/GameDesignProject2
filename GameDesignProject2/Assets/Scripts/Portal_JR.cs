using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Portal_JR : MonoBehaviour

{
    public string sceneName;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("portal collision");
        if (other.gameObject.tag == ("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
