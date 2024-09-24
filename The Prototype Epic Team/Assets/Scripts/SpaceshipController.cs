using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float horizontalInput;

    public float verticalInput;

    public float moveSpeed = 5.0f;

    public float turnSpeed;


    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        verticalInput = Input.GetAxis("Vertical");

        if(verticalInput > 0)
        {
            transform.Translate(Vector3.forward * verticalInput * moveSpeed * Time.deltaTime);
        }


        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
    }
}
