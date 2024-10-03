//Scott Abbinanti 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        transform.eulerAngles = new Vector3(0, 0, Random.value * 360.0f);

    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.x > 35 || transform.position.x < -35 || transform.position.y > 35 || transform.position.y < -35)
        {
            Destroy(this.gameObject);
        }
    }

    private void SetTrajectory(Vector3 direction)
    {
        //Debug.Log("Trajectory set");

        rb.AddForce(direction);
    }
}
