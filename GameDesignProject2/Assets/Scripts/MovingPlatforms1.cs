using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms1 : MonoBehaviour
{
    public float speed;
    float time = 2.5f;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();




    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }





    private void Move()
    {
        time += Time.deltaTime;
        if (time % 10 > 5)
        {
            Vector3 moveDirection = transform.TransformDirection(Vector3.forward) * speed;
            characterController.Move(moveDirection);
        }
        else
        {
            Vector3 moveDirection = transform.TransformDirection(Vector3.forward) * -speed;
            characterController.Move(moveDirection);
        }
    }
}
